using Budget.Application.Events;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;

public class LinkAccountToRollupAccountService : Receiver<AccountLinkedToRollup>
{
    public static LinkAccountToRollupAccountService Instance { get; } = new LinkAccountToRollupAccountService();

    public override void Serve(AccountLinkedToRollup @event)
    {
        var rollupAccountProjection = RollupAccount.Get(@event.RollupAccountId);
        if (rollupAccountProjection == null) 
        {
            throw new InvalidOperationException("Event is missing.");
        }
        if (rollupAccountProjection.LinkedAccountIds.Contains(@event.AccountId))
        {
            return; //Account is already linked.
        }
        rollupAccountProjection.LinkedAccountIds.Add(@event.AccountId);
        rollupAccountProjection.Save(); // Assuming a Save method to persist changes
    }
}
