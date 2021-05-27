using Budget.Application.Events.Core;
using Budget.Application.Projection.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget.Application.Services.Core
{

    public abstract class Linker<TEvent, TSourceProjection, TTargetProjection> : Receiver<TEvent>
        where TEvent : Event<TEvent>
        where TSourceProjection : Projection<TSourceProjection>, new()
        where TTargetProjection : Projection<TTargetProjection>, new()
    {
        internal abstract List<Guid> GetSourceIds(TEvent @event);
        internal abstract List<Guid> GetTargetIds(List<TSourceProjection> sources);
        internal abstract void Link(TSourceProjection source, TTargetProjection target);
        internal List<Guid> Guids(Guid guid)
        {
            return new List<Guid>() { guid };
        }
        internal List<Guid> Guids(IEnumerable<Guid> guids)
        {
            return new List<Guid>(guids);
        }
        internal List<Guid> Guids(IEnumerable<Guid?> guids)
        {
            var guidsQuery = from nullableGuid in guids
                             where nullableGuid.HasValue
                             let guidString = nullableGuid.Value.ToString()
                             let guid = new Guid(guidString)
                             select guid;
            return guidsQuery.ToList();
        }
        public override void Serve(TEvent @event)
        {
            var sourceIds = GetSourceIds(@event);
            var sourceProjections = Projection<TSourceProjection>.Projections.FindAll(source => sourceIds.Contains(source.Id));
            var targetIds = GetTargetIds(sourceProjections);
            var targetProjections = Projection<TTargetProjection>.Projections.FindAll(target => targetIds.Contains(target.Id));
            sourceProjections.ForEach(source => targetProjections.ForEach(target => Link(source, target)));
        }
    }

}