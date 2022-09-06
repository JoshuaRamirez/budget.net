using Budget.Application.Events.Core;
using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Services.Creates
{
    public class CreateAccountService : Receiver<AccountRequested>
    {
        public CreateAccountService()
        {
            AccountRequested.Subscribe(this);
        }
        public override void Serve(AccountRequested @event)
        {
            // Create AccountProjection
            var accountProjection = new Account();
            accountProjection.AccountName = @event.AccountName;
            accountProjection.UserId = @event.UserId;
            Account.Projections.Add(accountProjection);
            // Publish AccountCreatedEvent
            var accountCreated = new AccountCreated();
            accountCreated.AccountId = accountProjection.Id;
            AccountCreated.Publish(accountCreated);
        }
    }
}
