using Budget.Application.Projection.Core;
using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projection
{
    public class PlannedDeposit : Projection<PlannedDeposit>
    {
        public PlannedDeposit()
        {
            DepositIds = new List<Guid>();
            ForecastIds = new List<Guid>();
        }
        public List<Guid> DepositIds { get; set; }
        public List<Guid> ForecastIds { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public int RepeatPeriod { get; set; }
        public Repetition RepeatMeasurement { get; set; }
        public int RepeatCount { get; set; }
        public DateTime StartDate { get; set; }
    }
}
