using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;

namespace Budget.Application.Services.Creates
{
    public class CreatePlannedExpenseService : Receiver<PlannedExpenseRequested>
    {
        public CreatePlannedExpenseService()
        {
            PlannedExpenseRequested.Subscribe(this);
        }
        public override void Serve(PlannedExpenseRequested @event)
        {
            // Create Projection
            var projection = new PlannedExpense();
            projection.Amount = @event.Amount;
            projection.ExpenseIds = new List<Guid>();
            projection.RepeatCount = @event.RepeatCount;
            projection.RepeatMeasurement = @event.RepeatMeasurement;
            projection.RepeatPeriod = @event.RepeatPeriod;
            projection.StartDate = @event.RepeatStart;
            PlannedExpense.Projections.Add(projection);
            // Publish Created Event
            var createdEvent = new PlannedExpenseCreated();
            createdEvent.PlannedExpenseId = projection.Id;
            PlannedExpenseCreated.Publish(createdEvent);
        }
    }
}
