using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Requested.Calculation
{
    public class ForecastCalculationRequested : Event<ForecastCalculationRequested>
    {
        public ForecastCalculationRequested()
        {
            EventName = nameof(ForecastCalculationRequested);
        }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public double StartingBalance { get; set; }
    }
}
