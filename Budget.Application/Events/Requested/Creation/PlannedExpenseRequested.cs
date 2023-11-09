using Budget.Application.Events.Core;
using Budget.Application.Projections.Core;
using System;

namespace Budget.Application.Events.Requested.Creation
{
    public class PlannedExpenseRequested : Event<PlannedExpenseRequested>
    {
        public PlannedExpenseRequested()
        {
            EventName = nameof(PlannedExpenseRequested);
        }
        public double? Amount { get; set; }
        public string? Description { get; set; }
        public int? RepeatPeriod { get; set; }
        public Repetition? RepeatMeasurement { get; set; }
        public int? RepeatCount { get; set; }
        public DateTime? StartDate { get; set; }
        public Guid? LedgerId { get; set; }
    }
}
