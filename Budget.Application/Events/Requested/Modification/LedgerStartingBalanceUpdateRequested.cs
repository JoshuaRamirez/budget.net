using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Requested.Modification
{
    public class LedgerStartingBalanceUpdateRequested : Event<LedgerStartingBalanceUpdateRequested>
    {
        public Guid LedgerId { get; set; }
        public double StartingBalance { get; set; }
    }
}
