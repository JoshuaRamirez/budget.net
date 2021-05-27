using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Requested.Creation
{
    public class TransactionRequested : Event<TransactionRequested>
    {
        public string Amount { get; set; }
        public Guid LedgerId { get; set; }
        public string Type { get; set; }
    }
}
