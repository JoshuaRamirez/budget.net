using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;

namespace Budget.Application.Services.Creates
{
    public class CreateForecastService : Receiver<ForecastRequested>
    {
        public static CreateForecastService Instance { get; } = new CreateForecastService();
        public override void Serve(ForecastRequested @event)
        {
            // Create Projection
            var projection = new Forecast();
            projection.Amount = @event.Amount;
            projection.CategoryId = @event.CategoryId;
            projection.Date = @event.Date;
            projection.Notes = @event.Notes;
            projection.PlannedTransactionIds = @event.PlannedTransactionIds ?? new List<Guid>();
            projection.Save();
            // Publish Created Event
            var createdEvent = new ForecastCreated();
            createdEvent.ForecastId = projection.Id;
            ForecastCreated.Publish(createdEvent);
        }
    }
}
