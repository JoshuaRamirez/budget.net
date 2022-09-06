using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projections
{
    public class Forecast : Projection<Forecast>
    {
        public Forecast()
        {
            PlannedDepositIds = new List<Guid>();
            PlannedExpenseIds = new List<Guid>();
        }
        public Guid AccountId { get; set; }
        public Guid CategoryId { get; set; }
        public List<Guid> PlannedDepositIds { get; set; }
        public List<Guid> PlannedExpenseIds { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
    }
}
