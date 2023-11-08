using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Requested.Creation
{
    public class LedgerRequested : Event<LedgerRequested>
    {
        public LedgerRequested()
        {
            EventName = nameof(LedgerRequested);
        }
        public Guid AccountId { get; set; }
        public string Type { get; set; }
    }
}
