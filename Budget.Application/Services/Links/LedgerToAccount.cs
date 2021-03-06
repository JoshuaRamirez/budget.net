using Budget.Application.Events.Created;
using Budget.Application.Projection;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.Application.Services.Links
{
    public class LedgerToAccount : Linker<LedgerCreated, Ledger, Account>
    {
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
