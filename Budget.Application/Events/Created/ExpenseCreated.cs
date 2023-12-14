using Budget.Application.Events.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Budget.Application.Events.Created
{
    public class ExpenseCreated: Event<ExpenseCreated>
    {
        public ExpenseCreated()
        {
            EventName = nameof(ExpenseCreated);
        }
        [Required] // Indicates that this property must have a value
        public Guid ExpenseId { get; set; }
        
        
    }
}
