using Budget.Application.Events.Core;
using Budget.Application.Projections.Core;
using System;

namespace Budget.Application.Events.Requested.Creation
{
    public class PlannedTransactionRequested : Event<PlannedTransactionRequested>
    {
        public PlannedTransactionRequested()
        {
            EventName = nameof(PlannedTransactionRequested);
        }
        public double Amount { get; set; }
        public string Description { get; set; }
        public int RepeatPeriod { get; set; }
        public Period PeriodMeasurement { get; set; }
        public int RepeatCount { get; set; }
        public DateTime StartDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public Guid LedgerId { get; set; }
        public Period RepeatMeasurement { get; set; }
    }
}
