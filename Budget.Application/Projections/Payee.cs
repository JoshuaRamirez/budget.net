using Budget.Application.Projection.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projection
{
    public class Payee : Projection<Payee>
    {
        public Payee()
        {
            ExpenseIds = new List<Guid>();
        }
        public List<Guid> ExpenseIds { get; set; }
        public string Description { get; set; }
        public string PayeeName { get; set; }
        public string Type { get; set; }
    }
}
