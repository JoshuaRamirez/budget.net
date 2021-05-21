using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Created
{
    public class UserCreated : Event<UserCreated>
    {
        public Guid UserId { get; internal set; }
    }
}
