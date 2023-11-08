using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;

namespace Budget.Application.Services.Creates
{
    public class CreateDepositService : Receiver<DepositRequested>
    {
        public static CreateDepositService Instance { get; } = new CreateDepositService();
        public override void Serve(DepositRequested @event)
        {
            // Create Projection
            var projection = new Deposit();
            projection.CategoryId = @event.CategoryId;
            projection.Description = @event.Description;
            projection.LedgerId = @event.LedgerId;
            projection.PayerId = @event.PayerId;
            projection.PlannedDepositId = @event.PlannedDepositId;
            projection.TransactionId = @event.TransactionId;
            projection.Save();
            // Publish Created Event
            var createdEvent = new DepositCreated();
            createdEvent.DepositId = projection.Id;
            DepositCreated.Publish(createdEvent);
        }
    }
}
