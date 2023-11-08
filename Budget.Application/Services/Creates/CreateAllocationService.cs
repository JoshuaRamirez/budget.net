using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;

namespace Budget.Application.Services.Creates
{
    public class CreateAllocationService : Receiver<AllocationRequested>
    {
        public static CreateAllocationService Instance { get; } = new CreateAllocationService();
        public override void Serve(AllocationRequested @event)
        {
            // Create Projection
            var projection = new Allocation();
            projection.LedgerId = @event.LedgerId;
            projection.TransactionId = @event.TransactionId;
            projection.Save();
            // Publish Created Event
            var createdEvent = new AllocationCreated();
            createdEvent.AllocationId = projection.Id;
            AllocationCreated.Publish(createdEvent);
        }
    }
}
