﻿using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class LedgerCreated: Event<LedgerCreated>
    {
        public Guid LedgerId { get; set; }
    }
}
