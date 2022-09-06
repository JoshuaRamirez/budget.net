using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreatePlannedExpenseServiceTests
    {
        [Fact]
        public void ShouldCreateProjection()
        {
            var service = new CreatePlannedExpenseService();
            var @event = new PlannedExpenseRequested();
            @event.Publish();
            var projection = PlannedExpense.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
