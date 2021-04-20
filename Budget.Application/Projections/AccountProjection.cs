using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projections
{
    public class AccountProjection : Projection<AccountProjection>
    {
        public string AccountName { get; internal set; }
        public object UserId { get; internal set; }
    }
}
