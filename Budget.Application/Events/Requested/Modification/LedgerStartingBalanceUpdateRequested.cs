using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Requested.Modification
{
    public class LedgerStartingBalanceUpdateRequested : Event<LedgerStartingBalanceUpdateRequested>
    {
        public LedgerStartingBalanceUpdateRequested()
        {
            EventName = nameof(LedgerStartingBalanceUpdateRequested);
        }
        public Guid LedgerId { get; set; }
        public double StartingBalance { get; set; }
    }
}
