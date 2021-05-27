using Budget.Application.Events.Core;
using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Requested.Creation
{
    public class PlannedDepositRequested : Event<PlannedDepositRequested>
    {
        public string Amount { get; set; }
        public string Description { get; set; }
        public int RepeatPeriod { get; set; }
        public RepeatMeasurement RepeatMeasurement { get; set; }
        public int RepeatCount { get; set; }
        public DateTime RepeatStart { get; set; }
    }
}
