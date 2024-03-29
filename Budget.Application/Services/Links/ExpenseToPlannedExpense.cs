﻿using Budget.Application.Events.Created;
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
            return Guids(sources.Select(expense => expense.PlannedExpenseId));
        }

        internal override void Link(Expense expense, PlannedExpense plannedExpense)
        {
            plannedExpense.ExpenseIds.Add(expense.Id);
        }
    }
}
