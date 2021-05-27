using Budget.Application.Events.Created;
using Budget.Application.Projection;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.Application.Services.Links
{
    public class ForecastToPlannedDeposit : Linker<ForecastCreated, Forecast, PlannedDeposit>
    {
        internal override List<Guid> GetSourceIds(ForecastCreated @event)
        {
            return Guids(@event.ForecastId);
        }

        internal override List<Guid> GetTargetIds(List<Forecast> sources)
        {
            return Guids(sources.SelectMany(x => x.PlannedDepositIds));
        }

        internal override void Link(Forecast source, PlannedDeposit target)
        {
            target.ForecastIds.Add(source.Id);
        }
    }
}
