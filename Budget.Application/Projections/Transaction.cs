using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projections
{
    public class Transaction : Projection<Transaction>
    {
        public Guid LedgerId { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
    }
}
