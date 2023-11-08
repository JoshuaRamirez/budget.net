using Budget.Application.Events.Requested.Modification;
using Budget.Application.Projections;
using Budget.Application.Services.Core;

public class UpdateLedgerStartingBalanceService : Receiver<LedgerStartingBalanceUpdateRequested>
{
    public static UpdateLedgerStartingBalanceService Instance { get; } = new UpdateLedgerStartingBalanceService();
    public override void Serve(LedgerStartingBalanceUpdateRequested @event)
    {
        var ledger = Ledger.Get(@event.LedgerId);
        if (ledger.StartingBalance != 0)
        {
            //TODO: Need test(s) on this logic
            ledger.Balance -= ledger.StartingBalance;
        }
        ledger.StartingBalance = @event.StartingBalance;
        ledger.Balance += ledger.StartingBalance;
        ledger.Save();
    }
}
