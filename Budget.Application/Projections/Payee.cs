﻿using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;

namespace Budget.Application.Projections
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
