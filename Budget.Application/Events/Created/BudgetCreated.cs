using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class BudgetCreated: Event<BudgetCreated>
    {
        public BudgetCreated()
        {
            EventName = nameof(BudgetCreated);
        }
        public Guid BudgetId { get; set; }
    }
}
