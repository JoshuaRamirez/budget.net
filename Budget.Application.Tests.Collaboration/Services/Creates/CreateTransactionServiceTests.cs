using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;

namespace Budget.Application.Tests.Collaboration.Services.Creates;
[TestClass]
public class CreateTransactionServiceTests
{
    public CreateTransactionServiceTests()
    {
        Runtime.Stop();
        Runtime.Start();
    }

    [TestMethod]
    public void ShouldCreateProjection()
    {
        new UserRequested().Publish();
        var ledger = Ledger.Projections[0];
        var @event = new TransactionRequested();
        @event.LedgerId = ledger.Id;
        @event.Publish();
        var projection = Transaction.Projections[0];
        Assert.IsNotNull(projection);
    }
}