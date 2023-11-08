using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class PlannedExpenseCreated: Event<PlannedExpenseCreated>
    {
        public PlannedExpenseCreated()
        {
            EventName = nameof(PlannedExpenseCreated);
        }
        public Guid PlannedExpenseId { get; set; }
    }
}
