using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class AccountCreatedEvent : Event<AccountCreatedEvent>
    {
        public Guid AccountId { get; set; }
    }
}
