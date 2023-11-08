using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Requested.Creation
{
    public class AllocationRequested : Event<AllocationRequested>
    {
        public AllocationRequested()
        {
            EventName = nameof(AllocationRequested);
        }
        public Guid LedgerId { get; set; }
        public Guid TransactionId { get; set; }
    }
}
