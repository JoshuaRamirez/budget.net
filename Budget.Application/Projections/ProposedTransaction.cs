using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projections
{
    public class ProposedTransaction : Projection<ProposedTransaction>
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public Guid PlannedTransactionId { get; set; }
        public string TransactionType { get; set; }
    }
}
