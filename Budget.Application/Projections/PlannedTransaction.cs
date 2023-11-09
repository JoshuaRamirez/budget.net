using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;

namespace Budget.Application.Projections
{
    public class PlannedTransaction : Projection<PlannedTransaction>
    {
        public PlannedTransaction()
        {
            ProposedTransactionIds = new List<Guid>();
        }
        public double Amount { get; set; }
        public string Description { get; set; }
        public int RepeatPeriod { get; set; }
        public Period RepeatMeasurement { get; set; }
        public int RepeatCount { get; set; }
        public List<Guid> ProposedTransactionIds { get; set; }
        public int TimesRepeated { get; set; }
        public DateTime StartDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public Guid PublishingUserId { get; internal set; }
    }
}
