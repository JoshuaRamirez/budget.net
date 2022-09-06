using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Services.Core;

namespace Budget.Application.Services.Creates
{
    public class CreateBudgetService : Receiver<BudgetRequested>
    {
        public CreateBudgetService()
        {
            BudgetRequested.Subscribe(this);
        }
        public override void Serve(BudgetRequested @event)
        {
            // Create Projection
            var budget = new Projections.Budget();
            budget.BudgetName = @event.BudgetName;
            budget.SubBudgetIds = @event.SubBudgetIds;
            budget.SuperBudgetIds = @event.SuperBudgetIds;
            Projections.Budget.Projections.Add(budget);
            // Publish Created Event
            var createdEvent = new BudgetCreated();
            createdEvent.BudgetId = budget.Id;
            BudgetCreated.Publish(createdEvent);
        }
    }
}
