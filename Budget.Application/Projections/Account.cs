using Budget.Application.Projection.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projection
{
    public class Account : Projection<Account>
    {
        public Guid LedgerId { get; set; }
        public Guid UserId { get; set; }
        public string AccountName { get; set; }
        public string Type { get; set; }
    }
}
