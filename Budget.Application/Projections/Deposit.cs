using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projections
{
    public class Deposit : Projection<Deposit>
    {
        public Guid CategoryId { get; set; }
        public Guid LedgerId { get; set; }
        public Guid PayerId { get; set; }
        public Guid? PlannedDepositId { get; set; }
        public Guid TransactionId { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
    }
}
