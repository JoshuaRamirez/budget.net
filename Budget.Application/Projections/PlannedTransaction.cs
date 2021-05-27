using Budget.Application.Projection.Core;
using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projection
{
    public class PlannedTransaction : Projection<PlannedTransaction>
    {
        public PlannedTransaction()
        {
            ProposedTransactionIds = new List<Guid>();
        }
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int RepeatPeriod { get; set; }
        public RepeatMeasurement RepeatMeasurement { get; set; }
        public int RepeatCount { get; set; }
        public List<Guid> ProposedTransactionIds { get; set; }
        public int TimesRepeated { get; set; }
        public DateTime StartDate { get; set; }
        public string TransactionType { get; set; }
    }
}
