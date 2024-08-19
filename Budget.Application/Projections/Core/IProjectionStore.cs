using System.Collections.Generic;

namespace Budget.Application.Projections.Core;
internal interface IProjectionStore
{
    void Add<TProjection>(TProjection projection) where TProjection : Projection<TProjection>;
    void Clear();
    List<TProjection> Projections<TProjection>() where TProjection : Projection<TProjection>;
    void Remove<TProjection>(TProjection projection) where TProjection : Projection<TProjection>;
}