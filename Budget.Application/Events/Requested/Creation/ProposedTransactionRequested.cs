using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Requested.Creation
{
    public class ProposedTransactionRequested : Event<ProposedTransactionRequested>
    {
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid PlannedTransactionId { get; set; }
        public string TransactionType { get; set; }
    }
}
