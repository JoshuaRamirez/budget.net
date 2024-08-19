using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Budget.Application.Events.Core;
public static class Bus
{
    private static readonly SemaphoreSlim _semaphore = new(1, 1);
    private static readonly Dictionary<Type, List<dynamic>> _subscribers = new();

    public static void Clear()
    {
        _semaphore.Wait();
        try
        {
            _subscribers.Clear();
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public static void Subscribe<TEvent>(Action<TEvent> action) where TEvent : Event<TEvent>
    {
        _semaphore.Wait();
        try
        {
            var type = typeof(TEvent);
            if (!_subscribers.ContainsKey(type))
            {
                _subscribers[type] = new List<dynamic>();
            }
            _subscribers[type].Add(action as dynamic);
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public static List<Action<TEvent>> Subscribers<TEvent>() where TEvent : Event<TEvent>
    {
        _semaphore.Wait();
        try
        {
            var type = typeof(TEvent);
            if (!_subscribers.ContainsKey(type))
            {
                _subscribers[type] = new List<dynamic>();
            }
            var collection = _subscribers[type];
            return collection.Cast<Action<TEvent>>().ToList();
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public static void UnSubscribe<TEvent>(Action<TEvent> action) where TEvent : Event<TEvent>
    {
        _semaphore.Wait();
        try
        {
            var type = typeof(TEvent);
            if (_subscribers.ContainsKey(type))
            {
                _subscribers[type].Remove(action as dynamic);
            }
        }
        finally
        {
            _semaphore.Release();
        }
    }
}