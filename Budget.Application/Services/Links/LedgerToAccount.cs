using Budget.Application.Events.Created;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.Application.Services.Links
{
    public class LedgerToAccount : Linker<LedgerCreated, Ledger, Account>
    {
        public static LedgerToAccount Instance { get; } = new LedgerToAccount();
        internal override List<Guid> GetSourceIds(LedgerCreated @event)
        {
            return Guids(@event.LedgerId);
        }

        internal override List<Guid> GetTargetIds(List<Ledger> sources)
        {
            return Guids(sources.Select(x => x.AccountId));
        }

        internal override void Link(Ledger source, Account target)
        {
            target.LedgerId = source.Id;
        }
    }
}
