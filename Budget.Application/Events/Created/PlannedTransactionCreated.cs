﻿using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class PlannedTransactionCreated: Event<PlannedTransactionCreated>
    {
        public Guid PlannedTransactionId { get; set; }
    }
}
