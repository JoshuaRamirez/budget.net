using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class DepositCreated: Event<DepositCreated>
    {
        public Guid DepositId { get; set; }
    }
}
