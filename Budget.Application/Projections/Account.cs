using Budget.Application.Projection.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projection
{
    public class Account : Projection<Account>
    {
        public string AccountName { get; internal set; }
        public Guid UserId { get; internal set; }
    }
}
