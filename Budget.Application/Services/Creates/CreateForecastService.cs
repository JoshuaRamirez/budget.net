using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;

namespace Budget.Application.Services.Creates
{
    public class CreateForecastService : Receiver<ForecastRequested>
    {
        public CreateForecastService()
        {
            ForecastRequested.Subscribe(this);
        }
        public override void Serve(ForecastRequested @event)
        {
            // Create Projection
            var projection = new Forecast();
            projection.Amount = @event.Amount;
            projection.CategoryId = @event.CategoryId;
            projection.Date = @event.Date;
            projection.Notes = @event.Notes;
            projection.PlannedDepositIds = @event.PlannedDepositIds;
            projection.PlannedExpenseIds = @event.PlannedExpenseIds;
            Forecast.Projections.Add(projection);
            // Publish Created Event
            var createdEvent = new ForecastCreated();
            createdEvent.ForecastId = projection.Id;
            ForecastCreated.Publish(createdEvent);
        }
    }
}
