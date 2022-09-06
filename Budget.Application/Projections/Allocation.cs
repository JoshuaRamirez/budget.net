using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projections
{
    public class Allocation : Projection<Allocation>
    {
        public Guid LedgerId { get; set; }
        public Guid TransactionId { get; set; }
    }
}
