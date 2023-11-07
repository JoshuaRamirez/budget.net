using Budget.Application.Events.Core;
using Budget.Application.Events.Created;
using Budget.Application.Projections;
using System.Threading.Tasks;
using Xunit;

public class UpdateLedgerBalanceServiceTests
{

    [Fact]
    public void ShouldUpdateWithAllocation()
    {
        var ledger = new Ledger();
        ledger.Save();

        var transaction = new Transaction();
        transaction.Amount = -1;
        transaction.LedgerId = ledger.Id;
        transaction.Save();

        var transactionCreatedEvent = new TransactionCreated();
        transactionCreatedEvent.TransactionId = transaction.Id;
        transactionCreatedEvent.Publish();

        var projection = Transaction.GetFirst();

        Assert.Equal(1, projection.Balance);
    }
}
