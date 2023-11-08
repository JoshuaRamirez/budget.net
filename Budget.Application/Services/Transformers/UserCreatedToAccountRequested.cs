using Budget.Application.Events.Core;
using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Services.Core;

namespace Budget.Application.Services.Transformers
{
    public class UserCreatedToAccountRequested : Transformer<UserCreated, AccountRequested>
    {
        public static UserCreatedToAccountRequested Instance { get; } = new UserCreatedToAccountRequested();
        public UserCreatedToAccountRequested() : base(userCreatedEvent =>
        {
            var accountRequestedEvent = new AccountRequested();
            accountRequestedEvent.AccountName = "Income";
            accountRequestedEvent.Type = "System";
            accountRequestedEvent.UserId = userCreatedEvent.UserId;
            return accountRequestedEvent;
        }) {}
    }
}
