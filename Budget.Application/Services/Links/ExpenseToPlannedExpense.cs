using Budget.Application.Events.Created;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget.Application.Services.Links
{
    public class ExpenseToPlannedExpense : Linker<ExpenseCreated, Expense, PlannedExpense>
    {
        public static ExpenseToPlannedExpense Instance { get; } = new ExpenseToPlannedExpense();
        internal override List<Guid> GetSourceIds(ExpenseCreated @event)
        {
            return Guids(@event.ExpenseId);
        }

        internal override List<Guid> GetTargetIds(List<Expense> sources)
        {
            return Guids(sources.Select(x => x.PlannedExpenseId));
        }

        internal override void Link(Expense source, PlannedExpense target)
        {
            target.ExpenseIds.Add(source.Id);
        }
    }
}
