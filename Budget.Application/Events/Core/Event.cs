using Budget.Application.Core;
using Budget.Application.Services;
using System;
using System.Collections.Generic;

namespace Budget.Application.Events.Core
{
    public abstract class Event<TEvent> where TEvent : Event<TEvent>
    {
        static Event()
        {
            store = new List<Event<TEvent>>();
            subscribers = new List<Receiver<TEvent>>();
        }
        public Event()
        {
            Id = new Guid();
            PublishingUserId = User.Id;
        }
        private static List<Receiver<TEvent>> subscribers { get; set; }
        private static List<Event<TEvent>> store { get; set; }
        public Guid Id { get; set; }
        public Guid PublishingUserId { get; set; }
        public string EventName { get; set; }
        public void Publish()
        {
            TEvent @event = (TEvent)this;
            Event<TEvent>.Publish(@event);
        }

        public static void Publish(TEvent @event)
        {
            store.Add(@event);
            foreach (var subscriber in subscribers)
            {
                subscriber.Serve(@event);
            }
        }
        public static void Subscribe(Receiver<TEvent> subscriber)
        {
            subscribers.Add(subscriber);
        }
    }
}
