using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class TransactionCreated: Event<TransactionCreated>
    {
        public TransactionCreated()
        {
            EventName = nameof(TransactionCreated);
        }
        public Guid TransactionId { get; set; }
    }
}
