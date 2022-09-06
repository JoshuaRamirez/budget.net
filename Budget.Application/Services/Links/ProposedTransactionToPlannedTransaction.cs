using Budget.Application.Events.Created;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.Application.Services.Links
{
    public class ProposedTransactionToPlannedTransaction : Linker<ProposedTransactionCreated, ProposedTransaction, PlannedTransaction>
    {
        internal override List<Guid> GetSourceIds(ProposedTransactionCreated @event)
        {
            return Guids(@event.ProposedTransactionId);
        }

        internal override List<Guid> GetTargetIds(List<ProposedTransaction> sources)
        {
            return Guids(sources.Select(x => x.PlannedTransactionId));
        }

        internal override void Link(ProposedTransaction source, PlannedTransaction target)
        {
            target.ProposedTransactionIds.Add(source.Id);
        }
    }
}
