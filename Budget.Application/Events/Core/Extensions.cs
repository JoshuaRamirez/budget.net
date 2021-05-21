using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;

namespace Budget.Application.Events.Core
{
    public static class Extensions
    {
        public static LedgerRequested ToLedgerRequested(this AccountCreated accountCreated)
        {
            var ledgerRequested = new LedgerRequested();
            return ledgerRequested;
        }
        public static PlannedTransactionRequested ToPlannedTransactionRequested(this PlannedDepositCreated plannedDepositCreated)
        {
            var plannedTransactionRequested = new PlannedTransactionRequested();
            return plannedTransactionRequested;
        }
        public static PlannedTransactionRequested ToPlannedTransactionRequested(this PlannedExpenseCreated plannedExpenseCreated)
        {
            var plannedTransactionRequested = new PlannedTransactionRequested();
            return plannedTransactionRequested;
        }
        public static ProposedTransactionRequested ToProposedTransactionRequested(this PlannedTransactionCreated plannedTransactionCreated)
        {
            var proposedTransactionRequested = new ProposedTransactionRequested();
            return proposedTransactionRequested;
        }
        public static AccountRequested ToAccountRequestedEvent(this UserCreated userCreatedEvent)
        {
            var accountRequestedEvent = new AccountRequested();
            accountRequestedEvent.AccountName = "Income";
            accountRequestedEvent.Type = "System";
            accountRequestedEvent.UserId = userCreatedEvent.UserId;
            return accountRequestedEvent;
        }
    }
}
