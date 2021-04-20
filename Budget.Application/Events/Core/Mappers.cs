using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Core
{
    public static class Mappers
    {
        public static AccountRequestedEvent ToAccountRequestedEvent(this UserCreatedEvent userCreatedEvent)
        {
            var accountRequestedEvent = new AccountRequestedEvent();
            accountRequestedEvent.AccountName = "Income";
            accountRequestedEvent.Type = "System";
            accountRequestedEvent.UserId = userCreatedEvent.UserId;
            return accountRequestedEvent;
        }
    }
}
