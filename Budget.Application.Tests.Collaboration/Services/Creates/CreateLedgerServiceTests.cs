using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;

namespace Budget.Application.Tests.Collaboration.Services.Creates;
[TestClass]
public class CreateLedgerServiceTests
{
    public CreateLedgerServiceTests()
    {
        Runtime.Stop();
        Runtime.Start();
    }

    [TestMethod]
    public void ShouldCreateProjection()
    {
        var @event = new LedgerRequested();
        @event.Publish();
        var projection = Ledger.Projections[0];
        Assert.IsNotNull(projection);
    }
}