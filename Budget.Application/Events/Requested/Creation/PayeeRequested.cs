using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Requested.Creation
{
    public class PayeeRequested : Event<PayeeRequested>
    {
        public string Description { get; set; }
        public string PayeeName { get; set; }
        public string Type { get; set; }
    }
}
