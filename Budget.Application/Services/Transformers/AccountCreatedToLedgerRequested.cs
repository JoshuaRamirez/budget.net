using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System.Linq;

namespace Budget.Application.Services.Transformers
{
    public class AccountCreatedToLedgerRequested : Transformer<AccountCreated, LedgerRequested>
    {
        public static AccountCreatedToLedgerRequested Instance { get; } = new AccountCreatedToLedgerRequested();
        public AccountCreatedToLedgerRequested() : base(accountCreated =>
        {
            var ledgerRequested = new LedgerRequested();
            var account = Account.Projections.Single(account => account.Id == accountCreated.AccountId);
            ledgerRequested.AccountId = account.Id;
            ledgerRequested.Type = account.Type;
            return ledgerRequested;
        }) {}
    }
}
