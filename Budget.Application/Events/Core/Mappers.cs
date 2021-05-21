using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Core
{
    public static class Mappers
    {
        public static Func<AccountCreated, LedgerRequested> AccountCreatedToLedgerRequested = x => x.ToLedgerRequested();
        public static Func<PlannedDepositCreated, PlannedTransactionRequested> PlannedDepositToPlannedTransactionRequested = x => x.ToPlannedTransactionRequested();
        public static Func<PlannedExpenseCreated, PlannedTransactionRequested> PlannedExpenseCreatedToPlannedTransactionRequested = x => x.ToPlannedTransactionRequested();
        public static Func<PlannedTransactionCreated, ProposedTransactionRequested> PlannedTransactionCreatedToProposedTransactionRequested = x => x.ToProposedTransactionRequested();
        public static Func<UserCreated, AccountRequested> UserCreatedToAccountRequested = x => x.ToAccountRequestedEvent();
    }
}
