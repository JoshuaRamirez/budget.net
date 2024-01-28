using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;

namespace Budget.Application.Projections
{
    public class RollupAccount : Projection<RollupAccount>
    {
        public List<Guid> LinkedAccountIds { get; private set; }
        public List<Guid> LinkedTransactionIds { get; private set; }
        public object AccountName { get; internal set; }
        public Guid UserId { get; internal set; }

        public RollupAccount()
        {
            LinkedAccountIds = new List<Guid>();
            LinkedTransactionIds = new List<Guid>();
        }
    }
}
