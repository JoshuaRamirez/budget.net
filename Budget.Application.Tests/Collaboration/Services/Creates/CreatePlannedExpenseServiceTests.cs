using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreatePlannedExpenseServiceTests
    {
        public CreatePlannedExpenseServiceTests()
        {
            Runtime.Stop();
            Runtime.Start();
        }

        [Fact]
        public void ShouldCreateProjection()
        {
            var @event = new PlannedExpenseRequested();
            @event.Publish();
            var projection = PlannedExpense.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
