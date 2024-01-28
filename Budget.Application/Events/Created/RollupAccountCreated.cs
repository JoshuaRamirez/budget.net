using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class RollupAccountCreated : Event<RollupAccountCreated>
    {
        public RollupAccountCreated()
        {
            EventName = nameof(RollupAccountCreated);
        }
        public Guid Id { get; set; }
        public Guid RollupAccountId { get; internal set; }
    }
}
