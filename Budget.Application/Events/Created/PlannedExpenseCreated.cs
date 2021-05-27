using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Created
{
    public class PlannedExpenseCreated: Event<PlannedExpenseCreated>
    {
        public Guid PlannedExpenseId { get; set; }
    }
}
