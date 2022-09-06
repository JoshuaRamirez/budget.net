using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class ExpenseCreated: Event<ExpenseCreated>
    {
        public Guid ExpenseId { get; set; }
    }
}
