using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Created
{
    public class ForecastCreated: Event<ForecastCreated>
    {
        public Guid ForecastId { get; set; }
    }
}
