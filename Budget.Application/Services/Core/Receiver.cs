using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Services
{
    public abstract class Receiver<TEvent> where TEvent : Event<TEvent>
    {
        public abstract void Serve(TEvent @event);
    }
}
