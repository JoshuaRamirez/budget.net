using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class ForecastCreated: Event<ForecastCreated>
    {
        public Guid ForecastId { get; set; }
    }
}
