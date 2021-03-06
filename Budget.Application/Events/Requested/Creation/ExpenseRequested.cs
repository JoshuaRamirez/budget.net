using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Requested.Creation
{
    public class ExpenseRequested : Event<ExpenseRequested>
    {
        public Guid CategoryId { get; set; }
        public Guid Description { get; set; }
        public Guid LedgerId { get; set; }
        public Guid PayeeId { get; set; }
        public Guid PlannedExpenseId { get; set; }
        public Guid TransactionId { get; set; }
    }
}
