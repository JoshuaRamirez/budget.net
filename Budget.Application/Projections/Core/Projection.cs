using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget.Application.Projections.Core
{
    public abstract class Projection<TProjection> where TProjection : Projection<TProjection>
    {
        public Guid Id { get; set; }

        public Projection()
        {
            Id = Guid.NewGuid();
            IsNew = true;
        }
        public void Save()
        {
            var projections = ProjectionStore.Projections<TProjection>();
            var projection = projections.Find(x => x.Id == Id);
            if (projection == null)
            {
                projection = this as TProjection;
                ProjectionStore.Add(projection);
                projection.IsNew = true;
                projection.IsDirty = false;
            }
            else
            {
                projection.IsNew = false;
                projection.IsDirty = true;
            }
        }
        public static TProjection Get(Guid id)
        {
            var projections = ProjectionStore.Projections<TProjection>();
            var projection = projections.Find(x => x.Id == id);
            return projection;
        }
        public static List<TProjection> GetAll()
        {
            var projections = ProjectionStore.Projections<TProjection>();
            return new List<TProjection>(projections);
        }
        public static TProjection GetFirst()
        {
            var projections = ProjectionStore.Projections<TProjection>();
            var projection = projections.First();
            return projection;
        }
        public static TProjection GetLast()
        {
            var projections = ProjectionStore.Projections<TProjection>();
            var projection = projections.Last();
            return projection;
        }

        internal static List<TProjection> FindAll(Predicate<TProjection> value)
        {
            return ProjectionStore.Projections<TProjection>().FindAll(value).ToList();
        }

        public Boolean IsDirty { get; set; }
        public Boolean IsNew { get; set; }
        public static List<TProjection> Projections
        {
            get
            {
                return ProjectionStore.Projections<TProjection>();
            }
        }
    }
}
