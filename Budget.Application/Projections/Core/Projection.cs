using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget.Application.Projections.Core
{
    public abstract class Projection<TProjection> where TProjection : Projection<TProjection>
    {
        public Guid Id { get; set; }
        public static List<TProjection> Projections { get; set; }
        public Projection()
        {
            Id = Guid.NewGuid();
            Projections = new List<TProjection>();
        }
        public void Save()
        {
            var projection = Projections.Find(x => x.Id == Id);
            if (projection == null)
            {
                Projections.Add(projection);
                projection.IsNew = true;
                projection.IsDirty = false;
            } else
            {
                projection.IsNew = false;
                projection.IsDirty = true;
            }
        }
        public static TProjection Get(Guid id)
        {
            var projection = Projections.Find(x => x.Id == id);
            return projection;
        }
        public static List<TProjection> GetAll()
        {
            return new List<TProjection>(Projections);
        }
        public static TProjection GetFirst()
        {
            var projection = Projections.First();
            return projection;
        }
        public static TProjection GetLast()
        {
            var projection = Projections.Last();
            return projection;
        }
        public Boolean IsDirty { get; set; }
        public Boolean IsNew { get; set; }
    }
}
