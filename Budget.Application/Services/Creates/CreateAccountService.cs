using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;

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
            // Create Projection
            var projection = new Account();
            projection.AccountName = @event.AccountName;
            projection.UserId = @event.UserId;
            Account.Projections.Add(projection);
            // Publish Created Event
            var createdEvent = new AccountCreated();
            createdEvent.AccountId = projection.Id;
            AccountCreated.Publish(createdEvent);
        }
    }
}
