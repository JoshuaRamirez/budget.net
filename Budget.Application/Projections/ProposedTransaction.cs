﻿using Budget.Application.Projections.Core;
using System;

namespace Budget.Application.Projections
{
    public class ProposedTransaction : Projection<ProposedTransaction>
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public Guid PlannedTransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
