﻿using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;

namespace Budget.Application.Projections
{
    public class Ledger : Projection<Ledger>
    {
        public Ledger()
        {
            TransactionIds = new List<Guid>();
        }
        public Guid AccountId { get; set; }
        public List<Guid> TransactionIds { get; set; }
        public double Balance { get; set; }
        public double StartingBalance { get; set; }
        public string Type { get; set; }
    }
}
