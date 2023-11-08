using Budget.Application.Events.Created;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.Application.Services.Links
{
    public class TransactionToLedger : Linker<TransactionCreated, Transaction, Ledger>
    {
        public static TransactionToLedger Instance { get; } = new TransactionToLedger();
        internal override List<Guid> GetSourceIds(TransactionCreated @event)
        {
            return Guids(@event.TransactionId);
        }

        internal override List<Guid> GetTargetIds(List<Transaction> sources)
        {
            return Guids(sources.Select(x => x.LedgerId));
        }

        internal override void Link(Transaction source, Ledger target)
        {
            target.TransactionIds.Add(source.Id);
        }
    }
}
