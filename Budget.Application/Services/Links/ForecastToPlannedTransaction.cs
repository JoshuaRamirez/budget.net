using Budget.Application.Events.Created;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget.Application.Services.Links
{
    public class ForecastToPlannedTransaction : Linker<ForecastCreated, Forecast, PlannedDeposit>
    {
        public static ForecastToPlannedTransaction Instance { get; } = new ForecastToPlannedTransaction();
        internal override List<Guid> GetSourceIds(ForecastCreated @event)
        {
            return Guids(@event.ForecastId);
        }

        internal override List<Guid> GetTargetIds(List<Forecast> sources)
        {
            var plannedTransactionIds = sources.SelectMany(x => x.PlannedTransactionIds);
            return new List<Guid>(plannedTransactionIds);
        }

        internal override void Link(Forecast source, PlannedDeposit target)
        {
            target.ForecastIds.Add(source.Id);
        }
    }
}
