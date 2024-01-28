using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;

namespace Budget.Application.Services.Creates
{
    public class CreateRollupAccountService : Receiver<RollupAccountRequested>
    {
        public static CreateRollupAccountService Instance { get; } = new CreateRollupAccountService();
        public override void Serve(Events.Requested.Creation.RollupAccountRequested @event)
        {
            // Validate Event
            if (@event.UserId == Guid.Empty)
            {
                throw new ArgumentException($"The {nameof(AccountRequested)} event is missing the {nameof(@event.UserId)} property.");
            }
            // Create Projection
            var projection = new RollupAccount();
            projection.AccountName = @event.AccountName;
            projection.UserId = @event.UserId;
            // Save & Publish
            projection.Save();
            var createdEvent = new RollupAccountCreated();
            createdEvent.RollupAccountId = projection.Id;
            createdEvent.Publish();
        }
    }
}
