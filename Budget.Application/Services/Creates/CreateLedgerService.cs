using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;

namespace Budget.Application.Services.Creates
{
    public class CreateLedgerService : Receiver<LedgerRequested>
    {
        public CreateLedgerService()
        {
            LedgerRequested.Subscribe(this);
        }
        public override void Serve(LedgerRequested @event)
        {
            // Create Projection
            var projection = new Ledger();
            projection.AccountId = @event.AccountId;
            projection.Balance = 0;
            projection.TransactionIds = new List<Guid>();
            projection.Type = @event.Type;
            Ledger.Projections.Add(projection);
            // Publish Created Event
            var createdEvent = new LedgerCreated();
            createdEvent.LedgerId = projection.Id;
            LedgerCreated.Publish(createdEvent);
        }
    }
}
