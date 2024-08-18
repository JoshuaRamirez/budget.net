using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;

namespace Budget.Application.Tests.Collaboration.Services.Creates;
[TestClass]
public class CreateExpenseServiceTests
{
    public CreateExpenseServiceTests()
    {
        Runtime.Stop();
        Runtime.Start();
    }

    [TestMethod]
    public void ShouldCreateProjection()
    {
        var @event = new ExpenseRequested();
        @event.Publish();
        var projection = Expense.Projections[0];
        Assert.IsNotNull(projection);
    }
}