using Budget.Application.Events.Created;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.Application.Services.Links
{
    public class ForecastToPlannedExpense : Linker<ForecastCreated, Forecast, PlannedExpense>
    {
        internal override List<Guid> GetSourceIds(ForecastCreated @event)
        {
            return Guids(@event.ForecastId);
        }

        internal override List<Guid> GetTargetIds(List<Forecast> sources)
        {
            return Guids(sources.SelectMany(x => x.PlannedExpenseIds));
        }

        internal override void Link(Forecast source, PlannedExpense target)
        {
            target.ForecastIds.Add(source.Id);
        }
    }
}
