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
        public static CreatePlannedExpenseService Instance { get; } = new CreatePlannedExpenseService();
        public override void Serve(PlannedExpenseRequested @event)
        {
            // Create Projection
            var projection = new PlannedExpense();
            projection.Amount = @event.Amount;
            projection.ExpenseIds = new List<Guid>();
            projection.RepeatCount = @event.RepeatCount;
            projection.RepeatMeasurement = @event.RepeatMeasurement;
            projection.RepeatPeriod = @event.RepeatPeriod;
            projection.StartDate = @event.StartDate;
            projection.Save();
            // Publish Created Event
            var createdEvent = new PlannedExpenseCreated();
            createdEvent.PlannedExpenseId = projection.Id;
            PlannedExpenseCreated.Publish(createdEvent);
        }
    }
}
