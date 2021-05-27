using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Requested.Creation
{
    public class DepositRequested : Event<DepositRequested>
    {
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public Guid LedgerId { get; set; }
        public Guid PayerId { get; set; }
        public Guid PlannedDepositId { get; set; }
        public Guid TransactionId { get; set; }
    }
}
