using Budget.Application.Events.Created;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System.Linq;

public class TransactionInspectionService : Receiver<TransactionCreated>
{
    public static TransactionInspectionService Instance { get; } = new TransactionInspectionService();

    public override void Serve(TransactionCreated @event)
    {
        // Retrieve the transaction to get the LedgerId
        var transactionProjection = Transaction.Get(@event.TransactionId);
        if (transactionProjection == null)
        {
            return;
        }

        // Retrieve the ledger to get the AccountId
        var ledgerProjection = Ledger.Get(transactionProjection.LedgerId);
        if (ledgerProjection == null)
        {
            return;
        }

        var accountId = ledgerProjection.AccountId;
        var linkedRollupAccounts = RollupAccount.GetAll() // Assuming a method to get all rollup accounts
            .Where(ra => ra.LinkedAccountIds.Contains(accountId));

        foreach (var rollupAccount in linkedRollupAccounts)
        {
            if (!rollupAccount.LinkedTransactionIds.Contains(@event.TransactionId))
            {
                rollupAccount.LinkedTransactionIds.Add(@event.TransactionId);
                rollupAccount.Save(); // Assuming a Save method to persist changes
            }
        }
    }
}
