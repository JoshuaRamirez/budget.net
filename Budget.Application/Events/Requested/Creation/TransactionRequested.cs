using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Requested.Creation
{
    public class TransactionRequested : Event<TransactionRequested>
    {
        public TransactionRequested()
        {
            EventName = nameof(TransactionRequested);
        }
        public double Amount { get; set; }
        public Guid DestinationLedgerId { get; set; }
        public Guid LedgerId { get; set; }
        public Guid SourceLedgerId { get; set; }
        public string Type { get; set; }
    }
}
