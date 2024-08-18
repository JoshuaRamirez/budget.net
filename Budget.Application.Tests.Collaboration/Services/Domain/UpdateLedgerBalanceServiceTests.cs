using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;

namespace Budget.Application.Tests.Collaboration.Services.Domain;
[TestClass]
public class UpdateLedgerBalanceServiceTests
{
    [TestMethod]
    public void ShouldUpdateWithAllocation()
    {
        Runtime.Start();
        new UserRequested().Publish();
        var ledger = Ledger.GetFirst();
        var transactionRequested = new TransactionRequested();
        transactionRequested.Amount = -100;
        transactionRequested.LedgerId = ledger.Id;
        transactionRequested.Publish();
        Assert.AreEqual(100, ledger.Balance);
    }
}