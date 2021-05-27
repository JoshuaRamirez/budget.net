using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Created
{
    public class PlannedTransactionCreated: Event<PlannedTransactionCreated>
    {
        public Guid PlannedTransactionId { get; set; }
    }
}
