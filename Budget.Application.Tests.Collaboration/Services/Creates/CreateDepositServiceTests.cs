using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;

namespace Budget.Application.Tests.Collaboration.Services.Creates;
[TestClass]
public class CreateDepositServiceTests
{
    public CreateDepositServiceTests()
    {
        Runtime.Stop();
        Runtime.Start();
    }

    [TestMethod]
    public void ShouldCreateProjection()
    {
        var @event = new DepositRequested();
        @event.Publish();
        var projection = Deposit.Projections[0];
        Assert.IsNotNull(projection);
    }
}