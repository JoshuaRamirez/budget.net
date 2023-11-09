using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;

namespace Budget.Application.Events.Requested.Creation
{
    public class ForecastRequested : Event<ForecastRequested>
    {
        public ForecastRequested()
        {
            EventName = nameof(ForecastRequested);
        }
        public double Amount { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public List<Guid> PlannedTransactionIds { get; internal set; }
    }
}
