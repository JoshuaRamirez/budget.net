using Budget.Application.Events.Requested.Modification;
using Budget.Application.Projections;
using Budget.Application.Services.Core;

public class UpdateLedgerStartingBalanceService : Receiver<LedgerStartingBalanceUpdateRequested>
{
    public override void Serve(LedgerStartingBalanceUpdateRequested @event)
    {
        var ledger = Ledger.Get(@event.LedgerId);
        if (ledger.StartingBalance != 0)
        {
            ledger.Balance -= ledger.StartingBalance;
        }
        ledger.StartingBalance = @event.StartingBalance;
        ledger.Balance += ledger.StartingBalance;
        ledger.Save();
    }
}
