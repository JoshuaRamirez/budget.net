using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateExpenseServiceTests
    {
        public CreateExpenseServiceTests()
        {
            Runtime.Stop();
            Runtime.Start();
        }

        [Fact]
        public void ShouldCreateProjection()
        {
            var @event = new ExpenseRequested();
            @event.Publish();
            var projection = Expense.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
