using Budget.Application.Projection.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projection
{
    public class Budget : Projection<Budget>
    {
        public Budget()
        {
            this.DepositIds = new List<Guid>();
            this.ExpenseIds = new List<Guid>();
            this.SubBudgetIds = new List<Guid>();
            this.SuperBudgetIds = new List<Guid>();
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
