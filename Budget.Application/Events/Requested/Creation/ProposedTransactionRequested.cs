using Budget.Application.Events.Core;
using Budget.Application.Projections.Core;
using System;

namespace Budget.Application.Events.Requested.Creation
{
    public class ProposedTransactionRequested : Event<ProposedTransactionRequested>
    {
        public ProposedTransactionRequested()
        {
            EventName = nameof(ProposedTransactionRequested);
        }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid PlannedTransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
