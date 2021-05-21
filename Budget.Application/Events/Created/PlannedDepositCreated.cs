using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Created
{
    public class PlannedDepositCreated: Event<PlannedDepositCreated>
    {
        public Guid PlannedDepositId { get; set; }
    }
}
