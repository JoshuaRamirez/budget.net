using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Projections.Core
{
    internal static class ProjectionStore
    {
        private static Dictionary<Type, List<dynamic>> _projectionStore = new Dictionary<Type, List<dynamic>>();
        public static void Add<TProjection>(TProjection projection) where TProjection : Projection<TProjection>
        {
            var type = typeof(TProjection);
            if (!_projectionStore.ContainsKey(type))
            {
                _projectionStore[type] = new List<dynamic>();
            }
            var projections = _projectionStore[type];
            projections.Add(projection);
        }
        public static List<TProjection> Projections<TProjection>()
        {
            var type = typeof(TProjection);
            if (!_projectionStore.ContainsKey(type))
            {
                _projectionStore[type] = new List<dynamic>();
            }
            var projections = _projectionStore[type];
            var castProjections = projections.Cast<TProjection>().ToList();
            return castProjections;
        }
        public static void Remove<TProjection>(TProjection projection)
        {
            var type = typeof(TProjection);
            if (!_projectionStore.ContainsKey(type))
            {
                _projectionStore[type] = new List<dynamic>();
            }
            var projections = _projectionStore[type];
            projections.Remove(projection);
        }

        internal static void Clear()
        {
            _projectionStore.Clear();
        }
    }
}
