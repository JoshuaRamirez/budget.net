using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;

namespace Budget.Application.Tests.Collaboration.Services.Creates;
[TestClass]
public class CreatePlannedTransactionServiceTests
{
    public CreatePlannedTransactionServiceTests()
    {
        Runtime.Stop();
        Runtime.Start();
    }

    [TestMethod]
    public void ShouldCreateProjection()
    {
        var @event = new PlannedTransactionRequested();
        @event.Publish();
        var projection = PlannedTransaction.Projections[0];
        Assert.IsNotNull(projection);
    }
}