using System;
using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;

namespace Budget.Application.Services.Creates
{
    public class CreateExpenseService : Receiver<ExpenseRequested>
    {
        public static CreateExpenseService Instance { get; } = new CreateExpenseService();
        public override void Serve(ExpenseRequested @event)
        {
            // Create Projection
            var projection = new Expense();
            projection.Description = @event.Description;
            projection.LedgerId = @event.LedgerId;
            projection.PayeeId = @event.PayeeId;
            projection.TransactionId = Guid.NewGuid();
            projection.PlannedExpenseId = @event.PlannedExpenseId;
            projection.Save();
            // Publish Created Event
            var createdEvent = new ExpenseCreated();
            createdEvent.ExpenseId = projection.Id;
            ExpenseCreated.Publish(createdEvent);
        }
    }
}
