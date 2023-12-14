using Budget.Application.Events.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Budget.Application.Events.Requested.Creation
{
    public class ExpenseRequested : Event<ExpenseRequested>
    {
        public ExpenseRequested()
        {
            EventName = nameof(ExpenseRequested);
        }
        public Guid? CategoryId { get; set; }
        public string Description { get; set; }
        [Required]
        public Guid LedgerId { get; set; }
        public Guid? PayeeId { get; set; }
        public Guid? PlannedExpenseId { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive number.")]
        public decimal Amount { get; set; }
    }
}
