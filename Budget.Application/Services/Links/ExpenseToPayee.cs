using Budget.Application.Events.Created;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget.Application.Services.Links
{
    public class ExpenseToPayee : Linker<ExpenseCreated, Expense, Payee>
    {
        public static ExpenseToPayee Instance { get; } = new ExpenseToPayee();
        internal override List<Guid> GetSourceIds(ExpenseCreated @event)
        {
            return Guids(@event.ExpenseId);
        }

        internal override List<Guid> GetTargetIds(List<Expense> sources)
        {
            return Guids(sources.Select(x => x.PayeeId));
        }

        internal override void Link(Expense source, Payee target)
        {
            target.ExpenseIds.Add(source.Id);
        }
    }
}
