using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;

namespace Budget.Application.Services.Creates
{
    public class CreatePayeeService : Receiver<PayeeRequested>
    {
        public static CreatePayeeService Instance { get; } = new CreatePayeeService();
        public override void Serve(PayeeRequested @event)
        {
            // Create Projection
            var projection = new Payee();
            projection.Description = @event.Description;
            projection.PayeeName = @event.PayeeName;
            projection.Type = @event.Type;
            projection.Save();
            // Publish Created Event
            var createdEvent = new PayeeCreated();
            createdEvent.PayeeId = projection.Id;
            PayeeCreated.Publish(createdEvent);
        }
    }
}
