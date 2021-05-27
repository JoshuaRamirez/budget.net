using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Requested.Creation
{
    public class PayerRequested : Event<PayerRequested>
    {
        public string Description { get; set; }
        public string PayerName { get; set; }
        public string Type { get; set; }
    }
}
