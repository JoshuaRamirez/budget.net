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
            //Validate Event
            if (@event.Amount == null)
            {
                throw new ArgumentException($"The {nameof(PlannedDepositRequested)} event is missing the {nameof(@event.Amount)} property.");
            }
            if (@event.RepeatCount == null)
            {
                throw new ArgumentException($"The {nameof(PlannedDepositRequested)} event is missing the {nameof(@event.RepeatCount)} property.");
            }
            if (@event.RepeatMeasurement == null)
            {
                throw new ArgumentException($"The {nameof(PlannedDepositRequested)} event is missing the {nameof(@event.RepeatMeasurement)} property.");
            }
            if (@event.RepeatPeriod == null)
            {
                throw new ArgumentException($"The {nameof(PlannedDepositRequested)} event is missing the {nameof(@event.RepeatPeriod)} property.");
            }
            if (@event.StartDate == null)
            {
                throw new ArgumentException($"The {nameof(PlannedDepositRequested)} event is missing the {nameof(@event.StartDate)} property.");
            }
            if (@event.LedgerId == null)
            {
                throw new ArgumentException($"The {nameof(PlannedDepositRequested)} event is missing the {nameof(@event.LedgerId)} property.");
            }
            // Create Projection
            var projection = new PlannedDeposit();
            projection.Amount = @event.Amount.Value;
            projection.DepositIds = new List<Guid>();
            projection.RepeatCount = @event.RepeatCount.Value;
            projection.PeriodMeasurement = @event.RepeatMeasurement.Value;
            projection.RepeatPeriod = @event.RepeatPeriod.Value;
            projection.StartDate = @event.StartDate.Value;
            projection.LedgerId = @event.LedgerId.Value;
            projection.Save();
            // Publish Created Event
            var createdEvent = new PlannedDepositCreated();
            createdEvent.PlannedDepositId = projection.Id;
            PlannedDepositCreated.Publish(createdEvent);
        }
    }
}
