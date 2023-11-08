using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class ProposedTransactionCreated: Event<ProposedTransactionCreated>
    {
        public ProposedTransactionCreated()
        {
            EventName = nameof(ProposedTransactionCreated);
        }
        public Guid ProposedTransactionId { get; set; }
    }
}
