using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class AccountCreated : Event<AccountCreated>
    {
        public Guid AccountId { get; set; }
    }
}
