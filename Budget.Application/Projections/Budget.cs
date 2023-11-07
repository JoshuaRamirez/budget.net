using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;

namespace Budget.Application.Projections
{
    public class Budget : Projection<Budget>
    {
        public Budget()
        {
            DepositIds = new List<Guid>();
            ExpenseIds = new List<Guid>();
            SubBudgetIds = new List<Guid>();
            SuperBudgetIds = new List<Guid>();
        }
        public List<Guid> DepositIds { get; set; }
        public List<Guid> ExpenseIds { get; set; }
        public List<Guid> SubBudgetIds { get; set; }
        public List<Guid> SuperBudgetIds { get; set; }
        public string BudgetName { get; set; }
        public bool IsRepeating { get; set; }
        public int PeriodInDays { get; set; }
        public double Remaining { get; set; }
        public DateTime StartDate { get; set; }
        public string Type { get; set; }
    }
}
