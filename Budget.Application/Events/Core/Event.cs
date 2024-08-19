using System;
using Budget.Application.Core;
using Budget.Application.Services.Core;

namespace Budget.Application.Events.Core;
public abstract class Event<TEvent> where TEvent : Event<TEvent>
{
    public Event()
    {
        Id = new Guid();
        PublishingUserId = User.Id;
    }

    public Guid Id { get; set; }
    public Guid PublishingUserId { get; }
    public string EventName { get; protected set; }
    //private static List<Receiver<TEvent>> _subscribers { get; set; }
    //private static List<Event<TEvent>> _store { get; }

    public static void Clear()
    {
        Bus.Clear();
        //_store.Clear();
    }

    public void Publish()
    {
        var @event = (TEvent)this;
        Publish(@event);
    }

    public static void Publish(TEvent @event)
    {
        //_store.Add(@event);
        var subscribers = Bus.Subscribers<TEvent>();
        foreach (var subscriber in subscribers) subscriber(@event);
    }

    public static void Subscribe(Receiver<TEvent> subscriber)
    {
        Bus.Subscribe<TEvent>(subscriber.Serve);
    }

    public static void UnSubscribe(Receiver<TEvent> subscriber)
    {
        Bus.UnSubscribe<TEvent>(subscriber.Serve);
    }
}