using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Created
{
    public class ExpenseCreated: Event<ExpenseCreated>
    {
        public Guid ExpenseId { get; set; }
    }
}
