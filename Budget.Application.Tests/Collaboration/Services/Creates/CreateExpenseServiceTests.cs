using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateExpenseServiceTests
    {
        [Fact]
        public void ShouldCreateProjection()
        {
            var service = new CreateExpenseService();
            var @event = new ExpenseRequested();
            @event.Publish();
            var projection = Expense.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
