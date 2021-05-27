using Budget.Application.Events.Created;
using Budget.Application.Projection;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.Application.Services.Links
{
    public class ExpenseToPayee : Linker<ExpenseCreated, Expense, Payee>
    {
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
