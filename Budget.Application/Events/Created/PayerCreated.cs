using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class PayerCreated : Event<PayerCreated>
    {
        public Guid PayerId { get; set; }
    }
}
