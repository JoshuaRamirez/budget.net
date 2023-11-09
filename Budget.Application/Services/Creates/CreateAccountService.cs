using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;

namespace Budget.Application.Services.Creates
{
    public class CreateAccountService : Receiver<AccountRequested>
    {
        public static CreateAccountService Instance { get; } = new CreateAccountService();
        public override void Serve(AccountRequested @event)
        {
            // Validate Event
            if (@event.UserId == Guid.Empty)
            {
                throw new ArgumentException($"The {nameof(AccountRequested)} event is missing the {nameof(@event.UserId)} property.");
            }
            // Create Projection
            var projection = new Account();
            projection.AccountName = @event.AccountName;
            projection.UserId = @event.UserId;
            // Save & Publish
            projection.Save();
            var createdEvent = new AccountCreated();
            createdEvent.AccountId = projection.Id;
            AccountCreated.Publish(createdEvent);
        }
    }
}
