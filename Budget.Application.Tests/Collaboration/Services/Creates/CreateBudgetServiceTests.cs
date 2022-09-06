using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateBudgetServiceTests
    {
        [Fact]
        public void ShouldCreateProjection()
        {
            var service = new CreateBudgetService();
            var @event = new BudgetRequested();
            @event.Publish();
            var projection = Projections.Budget.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
