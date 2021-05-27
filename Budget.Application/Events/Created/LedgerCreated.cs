using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Created
{
    public class LedgerCreated: Event<LedgerCreated>
    {
        public Guid LedgerId { get; set; }
    }
}
