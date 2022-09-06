using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projections
{
    public class Transaction : Projection<Transaction>
    {
        public Guid LedgerId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public Guid DestinationLedgerId { get; internal set; }
        public Guid SourceLedgerId { get; internal set; }
    }
}
