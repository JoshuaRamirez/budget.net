using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class PayeeCreated : Event<PayeeCreated>
    {
        public Guid PayeeId { get; set; }
    }
}
