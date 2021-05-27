using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Requested.Creation
{
    public class LedgerRequested : Event<LedgerRequested>
    {
        public Guid AccountId { get; set; }
        public string Type { get; set; }
    }
}
