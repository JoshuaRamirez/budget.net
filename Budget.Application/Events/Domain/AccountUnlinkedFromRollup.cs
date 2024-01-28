using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events
{
    public class AccountUnlinkedFromRollup : Event<AccountUnlinkedFromRollup>
    {
        public AccountUnlinkedFromRollup()
        {
            EventName = nameof(AccountUnlinkedFromRollup);
        }

        public Guid RollupAccountId { get; set; }
        public Guid AccountId { get; set; }
    }
}
