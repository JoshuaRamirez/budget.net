using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget.Application.Events.Core
{
    public static class Bus
    {
        private static Dictionary<Type, List<dynamic>> _subscribers = new Dictionary<Type, List<dynamic>>();
        public static void Subscribe<TEvent>(Action<TEvent> action) where TEvent: Event<TEvent>
        {
            var type = typeof(TEvent);
            if (!_subscribers.ContainsKey(type))
            {
                _subscribers[type] = new List<dynamic>();
            }
            var subscribers = _subscribers[type];
            var dynamicAction = action as dynamic;
            subscribers.Add(dynamicAction);
        }

        public static List<Action<TEvent>> Subscribers<TEvent>() where TEvent : Event<TEvent>
        {
            var type = typeof(TEvent);
            if (!_subscribers.ContainsKey(type))
            {
                _subscribers[type] = new List<dynamic>();
            }
            var collection = _subscribers[type];
            if (collection == null)
            {
                collection = new List<dynamic>();
            }
            var castCollection = collection.Cast<Action<TEvent>>().ToList();
            return castCollection;
        }

        public static void UnSubscribe<TEvent>(Action<TEvent> action) where TEvent : Event<TEvent>
        {
            var type = typeof(TEvent);
            if (!_subscribers.ContainsKey(type))
            {
                _subscribers[type] = new List<dynamic>();
            }
            var subscribers = _subscribers[typeof(TEvent)];
            subscribers.Remove(action as Action<dynamic>);
        }

        public static void Clear()
        {
            _subscribers.Clear();
        }

    }
}
