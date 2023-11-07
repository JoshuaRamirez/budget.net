using Budget.Application.Projections.Core;
using System;

namespace Budget.Application.Projections
{
    public class Expense : Projection<Expense>
    {
        public Guid CategoryId { get; set; }
        public Guid LedgerId { get; set; }
        public Guid PayeeId { get; set; }
        public Guid PlannedExpenseId { get; set; }
        public Guid TransactionId { get; set; }
        public string Description { get; set; }
    }
}
