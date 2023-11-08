using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;

namespace Budget.Application.Services.Creates
{
    public class CreateAccountService : Receiver<AccountRequested>
    {
        public static CreateAccountService Instance { get; } = new CreateAccountService();
        public override void Serve(AccountRequested @event)
        {
            // Create Projection
            var projection = new Account();
            projection.AccountName = @event.AccountName;
            projection.UserId = @event.UserId;
            projection.Save();
            // Publish Created Event
            var createdEvent = new AccountCreated();
            createdEvent.AccountId = projection.Id;
            AccountCreated.Publish(createdEvent);
        }
    }
}
