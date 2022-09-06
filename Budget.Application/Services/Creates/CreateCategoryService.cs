using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;

namespace Budget.Application.Services.Creates
{
    public class CreateCategoryService : Receiver<CategoryRequested>
    {
        public CreateCategoryService()
        {
            CategoryRequested.Subscribe(this);
        }
        public override void Serve(CategoryRequested @event)
        {
            // Create Projection
            var projection = new Category();
            projection.CategoryName = @event.CategoryName;
            Category.Projections.Add(projection);
            // Publish Created Event
            var createdEvent = new CategoryCreated();
            createdEvent.CategoryId = projection.Id;
            CategoryCreated.Publish(createdEvent);
        }
    }
}
