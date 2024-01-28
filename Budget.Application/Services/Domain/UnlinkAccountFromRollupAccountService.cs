using Budget.Application.Events;
using Budget.Application.Projections;
using Budget.Application.Services.Core;

public class UnlinkAccountFromRollupAccountService : Receiver<AccountUnlinkedFromRollup>
{
    public static UnlinkAccountFromRollupAccountService Instance { get; } = new UnlinkAccountFromRollupAccountService();

    public override void Serve(AccountUnlinkedFromRollup @event)
    {
        var rollupAccountProjection = RollupAccount.Get(@event.RollupAccountId);
        if (rollupAccountProjection == null || !rollupAccountProjection.LinkedAccountIds.Contains(@event.AccountId))
        {
            return;
        }

        rollupAccountProjection.LinkedAccountIds.Remove(@event.AccountId);
        rollupAccountProjection.Save(); // Assuming a Save method to persist changes
    }
}
