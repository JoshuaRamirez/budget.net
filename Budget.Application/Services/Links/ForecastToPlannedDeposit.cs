using Budget.Application.Events.Created;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget.Application.Services.Links
{
    public class ForecastToPlannedDeposit : Linker<ForecastCreated, Forecast, PlannedDeposit>
    {
        public static ForecastToPlannedDeposit Instance { get; } = new ForecastToPlannedDeposit();
        internal override List<Guid> GetSourceIds(ForecastCreated @event)
        {
            return Guids(@event.ForecastId);
        }

        internal override List<Guid> GetTargetIds(List<Forecast> sources)
        {
            var allPlannedDepositIds = sources.SelectMany(x => x.PlannedDepositIds);
            return new List<Guid>();
        }

        internal override void Link(Forecast source, PlannedDeposit target)
        {
            target.ForecastIds.Add(source.Id);
        }
    }
}
