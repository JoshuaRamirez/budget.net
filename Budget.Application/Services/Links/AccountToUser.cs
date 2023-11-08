using Budget.Application.Events.Created;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.Application.Services.Links
{
    public class AccountToUser : Linker<AccountCreated, Account, User>
    {
        public static AccountToUser Instance { get; } = new AccountToUser();
        internal override List<Guid> GetSourceIds(AccountCreated @event)
        {
            return new List<Guid>() { @event.AccountId };
        }

        internal override List<Guid> GetTargetIds(List<Account> sources)
        {
            return new List<Guid>(sources.Select(x => x.UserId));
        }

        internal override void Link(Account source, User target)
        {
            target.AccountIds.Add(source.Id);
        }
    }
}
