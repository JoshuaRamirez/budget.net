using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Created
{
    public class ProposedTransactionCreated: Event<ProposedTransactionCreated>
    {
        public Guid ProposedTransactionId { get; set; }
    }
}
