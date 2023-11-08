using Budget.Application.Events.Core;

namespace Budget.Application.Services.Core
{
    public abstract class Receiver<TEvent> where TEvent : Event<TEvent>
    {
        public abstract void Serve(TEvent @event);
        public void Subscribe()
        {
            Event<TEvent>.Subscribe(this);
        }
        public void UnSubscribe()
        {
            Event<TEvent>.UnSubscribe(this);
        }
    }
}
