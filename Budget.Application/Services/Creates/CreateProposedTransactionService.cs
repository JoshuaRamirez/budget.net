using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;

namespace Budget.Application.Services.Creates
{
    public class CreateProposedTransactionService : Receiver<ProposedTransactionRequested>
    {
        public static CreateProposedTransactionService Instance { get; } = new CreateProposedTransactionService();
        public override void Serve(ProposedTransactionRequested @event)
        {
            // TODO: Ensure the repeat properties are base to this class.
            // TODO: Remove the duplicated properties on planned dep/exp classes.
            // Create Projection
            var projection = new ProposedTransaction();
            projection.Amount = @event.Amount;
            projection.Description = @event.Description;
            projection.PlannedTransactionId = @event.PlannedTransactionId;
            projection.TransactionType = @event.TransactionType;
            projection.Save();
            // Publish Created Event
            var createdEvent = new ProposedTransactionCreated();
            createdEvent.ProposedTransactionId = projection.Id;
            ProposedTransactionCreated.Publish(createdEvent);
        }
    }
}
