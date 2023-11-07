using Budget.Application.Projections.Core;
using System;

namespace Budget.Application.Projections
{
    public class Transaction : Projection<Transaction>
    {
        public Guid LedgerId { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
        public Guid DestinationLedgerId { get; internal set; }
        public Guid SourceLedgerId { get; internal set; }
    }
}
