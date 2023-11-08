using Budget.Application;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Xunit;

public class UpdateLedgerBalanceServiceTests
{

    [Fact]
    public void ShouldUpdateWithAllocation()
    {
        Runtime.Start();
        new UserRequested().Publish();
        var ledger = Ledger.GetFirst();
        var transactionRequested = new TransactionRequested();
        transactionRequested.Amount = -100;
        transactionRequested.LedgerId = ledger.Id;
        transactionRequested.Publish();
        Assert.Equal(100, ledger.Balance);
    }
}
