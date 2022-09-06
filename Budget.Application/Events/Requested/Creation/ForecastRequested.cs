using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Requested.Creation
{
    public class ForecastRequested : Event<ForecastRequested>
    {
        public double Amount { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public List<Guid> PlannedDepositIds { get; set; }
        public List<Guid> PlannedExpenseIds { get; set; }
    }
}
