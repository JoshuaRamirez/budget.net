using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Created
{
    public class UserCreatedEvent : Event<UserCreatedEvent>
    {
        public object UserId { get; internal set; }
    }
}
