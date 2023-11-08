using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;

namespace Budget.Application.Services.Creates
{
    public class CreatePlannedDepositService : Receiver<PlannedDepositRequested>
    {
        public static CreatePlannedDepositService Instance { get; } = new CreatePlannedDepositService();
        public override void Serve(PlannedDepositRequested @event)
        {
            // Create Projection
            var projection = new PlannedDeposit();
            projection.Amount = @event.Amount;
            projection.DepositIds = new List<Guid>();
            projection.RepeatCount = @event.RepeatCount;
            projection.RepeatMeasurement = @event.RepeatMeasurement;
            projection.RepeatPeriod = @event.RepeatPeriod;
            projection.StartDate = @event.startDate;
            projection.Save();
            // Publish Created Event
            var createdEvent = new PlannedDepositCreated();
            createdEvent.PlannedDepositId = projection.Id;
            PlannedDepositCreated.Publish(createdEvent);
        }
    }
}
