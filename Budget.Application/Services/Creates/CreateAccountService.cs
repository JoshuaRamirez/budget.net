using Budget.Application.Events.Core;
using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Services.Creates
{
    public class CreateAccountService : Receiver<AccountRequestedEvent>
    {
        public CreateAccountService()
        {
            AccountRequestedEvent.Subscribe(this);
        }
        public override void Serve(AccountRequestedEvent @event)
        {
            // Create AccountProjection
            var accountProjection = new AccountProjection();
            accountProjection.AccountName = @event.AccountName;
            accountProjection.UserId = @event.UserId;
            AccountProjection.Projections.Add(accountProjection);
            // Publish AccountCreatedEvent
            var accountCreated = new AccountCreatedEvent();
            accountCreated.AccountId = accountProjection.Id;
            AccountCreatedEvent.Publish(accountCreated);
        }
    }
}
