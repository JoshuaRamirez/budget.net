using System.Collections.Generic;
using System;
using Budget.Application.Events.Core;

namespace Budget.Application.Events.Requested.Creation
{
    public class RollupAccountRequested : Event<RollupAccountRequested>
    {
        public List<Guid> LinkedAccountIds { get; set; }
        public List<Guid> LinkedTransactionIds { get; set; }
        public Guid UserId { get; set; }
        public object AccountName { get; set; }
    }
}
