using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Requested.Creation
{
    public class UserRequestedEvent : Event<UserRequestedEvent>
    {
        public string UserName { get; set; }
    }
}
