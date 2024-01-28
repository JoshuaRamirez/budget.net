using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events
{
    public class AccountLinkedToRollup : Event<AccountLinkedToRollup>
    {
        public AccountLinkedToRollup()
        {
            EventName = nameof(AccountLinkedToRollup);
        }

        public Guid RollupAccountId { get; set; }
        public Guid AccountId { get; set; }
    }
}
