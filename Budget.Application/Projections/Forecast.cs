using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;

namespace Budget.Application.Projections
{
    public class Forecast : Projection<Forecast>
    {
        public Forecast()
        {
            PlannedTransactionIds = new List<Guid>();
        }
        public Guid AccountId { get; set; }
        public Guid CategoryId { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public List<Guid> PlannedTransactionIds { get; internal set; }
    }
}
