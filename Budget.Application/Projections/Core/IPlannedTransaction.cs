using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projection.Core
{
    public interface IPlannedTransaction
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public int RepeatPeriod { get; set; }
        public RepeatMeasurement RepeatMeasurement { get; set; }
        public int RepeatCount { get; set; }
        public DateTime StartDate { get; set; }
    }
}
