using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Requested.Creation
{
    public class AllocationRequested : Event<AllocationRequested>
    {
        public Guid LedgerId { get; set; }
        public Guid TransactionId { get; set; }
    }
}
