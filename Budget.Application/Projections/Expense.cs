using Budget.Application.Projection.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projection
{
    public class Expense : Projection<Expense>
    {
        public Guid CategoryId { get; set; }
        public Guid LedgerId { get; set; }
        public Guid PayeeId { get; set; }
        public Guid PlannedExpenseId { get; set; }
        public Guid TransactionId { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
    }
}
