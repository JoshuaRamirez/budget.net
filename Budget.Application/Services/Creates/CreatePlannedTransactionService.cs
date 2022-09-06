using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;

namespace Budget.Application.Services.Creates
{
    public class CreatePlannedTransactionService : Receiver<PlannedTransactionRequested>
    {
        public CreatePlannedTransactionService()
        {
            PlannedTransactionRequested.Subscribe(this);
        }
        public override void Serve(PlannedTransactionRequested @event)
        {
            // TODO: Ensure the repeat properties are base to this class.
            // TODO: Remove the duplicated properties on planned dep/exp classes.
            // Create Projection
            var projection = new PlannedTransaction();
            projection.Amount = @event.Amount;
            projection.Description = @event.Description;
            projection.RepeatCount = @event.RepeatCount;
            projection.RepeatMeasurement = @event.RepeatMeasurement;
            projection.RepeatPeriod = @event.RepeatPeriod;
            projection.StartDate = @event.RepeatStart;
            projection.TransactionType = @event.TransactionType;
            PlannedTransaction.Projections.Add(projection);
            // Publish Created Event
            var createdEvent = new PlannedTransactionCreated();
            createdEvent.PlannedTransactionId = projection.Id;
            PlannedTransactionCreated.Publish(createdEvent);
        }
    }
}
