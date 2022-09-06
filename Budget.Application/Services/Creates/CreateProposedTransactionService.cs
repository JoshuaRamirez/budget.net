using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;

namespace Budget.Application.Services.Creates
{
    public class CreateProposedTransactionService : Receiver<ProposedTransactionRequested>
    {
        public CreateProposedTransactionService()
        {
            ProposedTransactionRequested.Subscribe(this);
        }
        public override void Serve(ProposedTransactionRequested @event)
        {
            // TODO: Ensure the repeat properties are base to this class.
            // TODO: Remove the duplicated properties on planned dep/exp classes.
            // Create Projection
            var projection = new ProposedTransaction();
            projection.Amount = @event.Amount;
            projection.Description = @event.Description;
            projection.PlannedTransactionId = @event.PlannedTransactionId;
            projection.TransactionType = @event.TransactionType;
            ProposedTransaction.Projections.Add(projection);
            // Publish Created Event
            var createdEvent = new ProposedTransactionCreated();
            createdEvent.ProposedTransactionId = projection.Id;
            ProposedTransactionCreated.Publish(createdEvent);
        }
    }
}
