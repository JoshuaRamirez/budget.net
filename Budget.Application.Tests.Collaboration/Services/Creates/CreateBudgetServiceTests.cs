using Budget.Application.Events.Requested.Creation;

namespace Budget.Application.Tests.Collaboration.Services.Creates;
[TestClass]
public class CreateBudgetServiceTests
{
    public CreateBudgetServiceTests()
    {
        Runtime.Stop();
        Runtime.Start();
    }

    [TestMethod]
    public void ShouldCreateProjection()
    {
        var @event = new BudgetRequested();
        @event.Publish();
        var projection = Projections.Budget.Projections[0];
        Assert.IsNotNull(projection);
    }
}