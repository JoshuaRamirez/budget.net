using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;

namespace Budget.Application.Services.Creates
{
    public class CreatePayerService : Receiver<PayerRequested>
    {
        public static CreatePayerService Instance { get; }  = new CreatePayerService();
        public override void Serve(PayerRequested @event)
        {
            // Create Projection
            var projection = new Payer();
            projection.Description = @event.Description;
            projection.PayerName = @event.PayerName;
            projection.Type = @event.Type;
            projection.Save();
            // Publish Created Event
            var createdEvent = new PayerCreated();
            createdEvent.PayerId = projection.Id;
            PayerCreated.Publish(createdEvent);
        }
    }
}
