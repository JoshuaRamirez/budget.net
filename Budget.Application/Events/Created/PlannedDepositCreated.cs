using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class PlannedDepositCreated: Event<PlannedDepositCreated>
    {
        public Guid PlannedDepositId { get; set; }
    }
}
