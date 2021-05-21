using Budget.Application.Events.Core;
using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Services.Core;

namespace Budget.Application.Services.Transformers
{
    public class AccountCreatedToLedgerRequested : Transformer<AccountCreated, LedgerRequested>
    {
        public AccountCreatedToLedgerRequested() : base(Mappers.AccountCreatedToLedgerRequested) {}
    }
}
