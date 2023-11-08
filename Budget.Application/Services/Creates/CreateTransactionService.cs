using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;

namespace Budget.Application.Services.Creates
{
    public class CreateTransactionService : Receiver<TransactionRequested>
    {
        public static CreateTransactionService Instance { get; } = new CreateTransactionService();
        public override void Serve(TransactionRequested @event)
        {
            // Create Projection
            var projection = new Transaction();
            projection.Amount = @event.Amount;
            projection.DestinationLedgerId = @event.DestinationLedgerId;
            projection.LedgerId = @event.LedgerId;
            projection.SourceLedgerId = @event.SourceLedgerId;
            projection.Type= @event.Type;
            projection.Save();
            // Publish Created Event
            var createdEvent = new TransactionCreated();
            createdEvent.TransactionId = projection.Id;
            TransactionCreated.Publish(createdEvent);
        }
    }
}
