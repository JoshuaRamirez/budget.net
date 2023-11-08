using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class DepositCreated: Event<DepositCreated>
    {
        public DepositCreated()
        {
            EventName = nameof(DepositCreated);
        }
        public Guid DepositId { get; set; }
    }
}
