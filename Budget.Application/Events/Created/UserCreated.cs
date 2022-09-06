using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class UserCreated : Event<UserCreated>
    {
        public Guid UserId { get; internal set; }
    }
}
