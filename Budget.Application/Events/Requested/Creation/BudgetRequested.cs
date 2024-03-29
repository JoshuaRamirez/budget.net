﻿using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;

namespace Budget.Application.Events.Requested.Creation
{
    public class BudgetRequested: Event<BudgetRequested>
    {
        public BudgetRequested()
        {
            EventName = nameof(BudgetRequested);
        }
        public string BudgetName { get; set; }
        public List<Guid> SubBudgetIds { get; set; }
        public List<Guid> SuperBudgetIds { get; set; }
        public string Type { get; set; }
    }
}
