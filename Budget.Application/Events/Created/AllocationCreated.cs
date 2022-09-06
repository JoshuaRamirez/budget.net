using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class AllocationCreated : Event<AllocationCreated>
    {
        public Guid AllocationId { get; set; }
    }
}
