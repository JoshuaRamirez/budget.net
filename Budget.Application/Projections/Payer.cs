using Budget.Application.Projection.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projection
{
    public class Payer : Projection<Payer>
    {
        public Payer()
        {
            DepositIds = new List<Guid>();
        }
        public List<Guid> DepositIds { get; set; }
        public string Description { get; set; }
        public string PayerName { get; set; }
        public string Type { get; set; }
    }
}
