using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Services.Core
{
    public class Transformer<TEventIn, TEventOut> : Receiver<TEventIn>
        where TEventIn : Event<TEventIn>
        where TEventOut : Event<TEventOut>
    {
        private Func<TEventIn, TEventOut> convert { get; }
        public Transformer(Func<TEventIn, TEventOut> convert)
        {
            this.convert = convert;
        }
        public override void Serve(TEventIn @event)
        {
            var eventOut = this.convert(@event);
            eventOut.Publish();
        }
    }
}