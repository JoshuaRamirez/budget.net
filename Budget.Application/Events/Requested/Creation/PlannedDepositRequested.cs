using Budget.Application.Events.Core;
using Budget.Application.Projections.Core;
using System;

namespace Budget.Application.Events.Requested.Creation
{
    public class PlannedDepositRequested : Event<PlannedDepositRequested>
    {
        public PlannedDepositRequested()
        {
            EventName = nameof(PlannedDepositRequested);
        }
        public double? Amount { get; set; }
        public string? Description { get; set; }
        public int? RepeatPeriod { get; set; }
        public Period? RepeatMeasurement { get; set; }
        public int? RepeatCount { get; set; }
        public DateTime? StartDate { get; set; }
        public Guid? LedgerId { get; set; }
    }
}
