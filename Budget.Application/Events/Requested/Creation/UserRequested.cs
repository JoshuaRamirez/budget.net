using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Requested.Creation
{
    public class UserRequested : Event<UserRequested>
    {
        public UserRequested()
        {
            EventName = nameof(UserRequested);
        }
        public string UserName { get; set; }
    }
}
