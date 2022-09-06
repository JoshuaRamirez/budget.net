using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Requested.Creation
{
    public class TransactionRequested : Event<TransactionRequested>
    {
        public decimal Amount { get; set; }
        public Guid DestinationLedgerId { get; set; }
        public Guid LedgerId { get; set; }
        public Guid SourceLedgerId { get; set; }
        public string Type { get; set; }
    }
}
