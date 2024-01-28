using Budget.Application;
using Budget.Application.Core;
using Budget.Application.Events;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Xunit;

public class RollupAccountScenarioTests
{
    [Fact]
    public void ShouldLinkAccountToRollupAccountViaEvent()
    {
        Runtime.Start();
        new UserRequested().Publish(); // Simulate user and account creation
        var userProjection = UserProjection.GetFirst();
        var account = Account.GetFirst(); // Assuming this fetches the first account

        // Assume RollupAccountCreated event exists to create a new rollup account
        var rollupAccountRequested = new RollupAccountRequested();
        rollupAccountRequested.UserId = userProjection.Id;
        rollupAccountRequested.Publish();

        var rollupAccount = RollupAccount.GetFirst(); // Fetch the newly created rollup account

        var linkEvent = new AccountLinkedToRollup
        {
            RollupAccountId = rollupAccount.Id,
            AccountId = account.Id
        };
        linkEvent.Publish();

        // Re-fetch rollup account to check if account was linked
        rollupAccount = RollupAccount.Get(rollupAccount.Id);
        Assert.Contains(account.Id, rollupAccount.LinkedAccountIds);
    }

    [Fact]
    public void ShouldUnlinkAccountFromRollupAccountViaEvent()
    {
        Runtime.Start();
        new UserRequested().Publish(); // Simulate user and account creation
        var userProjection = UserProjection.GetFirst();
        var account = Account.GetFirst(); // Assuming this fetches the first account

        // Create and link account to rollup account
        var rollupAccountRequested = new RollupAccountRequested();
        rollupAccountRequested.UserId = userProjection.Id;
        rollupAccountRequested.Publish();
        var rollupAccount = RollupAccount.GetFirst(); // Fetch the newly created rollup account

        var linkEvent = new AccountLinkedToRollup
        {
            RollupAccountId = rollupAccount.Id,
            AccountId = account.Id
        };
        linkEvent.Publish();

        // Unlink account from rollup account
        var unlinkEvent = new AccountUnlinkedFromRollup
        {
            RollupAccountId = rollupAccount.Id,
            AccountId = account.Id
        };
        unlinkEvent.Publish();

        // Re-fetch rollup account to check if account was unlinked
        rollupAccount = RollupAccount.Get(rollupAccount.Id);
        Assert.DoesNotContain(account.Id, rollupAccount.LinkedAccountIds);
    }

    [Fact]
    public void ShouldAddTransactionToRollupAccountViaEvent()
    {
        Runtime.Start();
        new UserRequested().Publish(); // Simulate user and account creation
        var userProjection = UserProjection.GetFirst();
        var ledger = Ledger.GetFirst(); // Assuming this fetches the first ledger associated with the account

        // Assume RollupAccountCreated event exists to create a new rollup account
        var rollupAccountRequested = new RollupAccountRequested();
        rollupAccountRequested.UserId = userProjection.Id;
        rollupAccountRequested.Publish();
        var rollupAccount = RollupAccount.GetFirst(); // Fetch the newly created rollup account

        // Link the account to the rollup account
        var account = Account.GetFirst(); // Fetch the account associated with the ledger
        var linkEvent = new AccountLinkedToRollup
        {
            RollupAccountId = rollupAccount.Id,
            AccountId = account.Id
        };
        linkEvent.Publish();

        // Create a new transaction
        var transactionRequested = new TransactionRequested
        {
            Amount = -100,
            LedgerId = ledger.Id
        };
        transactionRequested.Publish();

        // Fetch the created transaction
        var transaction = Transaction.GetLast(); // Assuming this fetches the last created transaction

        // Re-fetch rollup account to check if transaction was added
        rollupAccount = RollupAccount.Get(rollupAccount.Id);
        Assert.Contains(transaction.Id, rollupAccount.LinkedTransactionIds);
    }
}
