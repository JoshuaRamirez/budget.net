using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Requested.Creation
{
    public class AccountRequestedEvent : Event<AccountRequestedEvent>
    {
        public string AccountName { get; set; }
        public string Type { get; set; }
        public object UserId { get; set; }
    }
}
