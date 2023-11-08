using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Requested.Creation
{
    public class AccountRequested : Event<AccountRequested>
    {
        public AccountRequested()
        {
            EventName = nameof(AccountRequested);
        }
        public string AccountName { get; set; }
        public string Type { get; set; }
        public Guid UserId { get; set; }
    }
}
