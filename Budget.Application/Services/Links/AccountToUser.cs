using Budget.Application.Events.Created;
using Budget.Application.Projection;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.Application.Services.Links
{
    public class AccountToUser : Linker<AccountCreated, Account, User>
    {
        public AccountToUser()
        {
            AccountCreated.Subscribe(this);
        }
        internal override List<Guid> GetSourceIds(AccountCreated @event)
        {
            return new List<Guid>() { @event.AccountId };
        }

        internal override List<Guid> GetTargetIds(List<Account> sourceProjections)
        {
            return new List<Guid>(sourceProjections.Select(x => x.UserId));
        }

        internal override void Link(Account targetProjection, User sourceProjection)
        {
            sourceProjection.AccountIds.Add(targetProjection.Id);
            targetProjection.UserId = sourceProjection.Id;
        }
    }
}
