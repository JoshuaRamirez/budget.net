using Budget.Application.Events.Created;
using Budget.Application.Projections;
using Budget.Application.Services.Core;

public class UpdateLedgerBalanceService : Receiver<TransactionCreated>
{
    public override void Serve(TransactionCreated @event)
    {
        var transactionProjection = Transaction.Get(@event.TransactionId);
        if (transactionProjection == null)
        {
            return;
        }
        var ledgerId = transactionProjection.LedgerId;
        var ledgerProjection = Ledger.Get(ledgerId);
        ledgerProjection.Balance -= transactionProjection.Amount;
        ledgerProjection.Save();
    }
}
