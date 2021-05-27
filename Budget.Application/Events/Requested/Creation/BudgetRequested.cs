using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Requested.Creation
{
    public class BudgetRequested: Event<BudgetRequested>
    {
        public string BudgetName { get; set; }
        public List<Guid> SubBudgetIds { get; set; }
        public List<Guid> SuperBudgetIds { get; set; }
        public string Type { get; set; }
    }
}
