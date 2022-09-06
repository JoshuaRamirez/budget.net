using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projections
{
    public class Account : Projection<Account>
    {
        public Guid LedgerId { get; set; }
        public Guid UserId { get; set; }
        public string AccountName { get; set; }
        public string Type { get; set; }
    }
}
