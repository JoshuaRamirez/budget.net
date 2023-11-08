using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Services.Core;

namespace Budget.Application.Services.Creates
{
    public class CreateBudgetService : Receiver<BudgetRequested>
    {
        public static CreateBudgetService Instance { get; } = new CreateBudgetService();
        public override void Serve(BudgetRequested @event)
        {
            // Create Projection
            var projection = new Projections.Budget();
            projection.BudgetName = @event.BudgetName;
            projection.SubBudgetIds = @event.SubBudgetIds;
            projection.SuperBudgetIds = @event.SuperBudgetIds;
            projection.Save();
            // Publish Created Event
            var createdEvent = new BudgetCreated();
            createdEvent.BudgetId = projection.Id;
            BudgetCreated.Publish(createdEvent);
        }
    }
}
