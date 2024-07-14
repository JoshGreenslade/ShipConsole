namespace Ship.EventSystem;

public static class EventBus
{
    private static readonly Dictionary<Type, List<Action<object>>> _eventHandlers = new Dictionary<Type, List<Action<object>>>();

    public static void Subscribe<T>(Action<T> handler) where T : Event
    {
        var eventType = typeof(T);
        if (!_eventHandlers.ContainsKey(eventType))
        {
            _eventHandlers[eventType] = new List<Action<object>>();
        }
        _eventHandlers[eventType].Add(e => handler((T)e));
    }

    public static void Unsubscribe<T>(Action<T> handler) where T : Event
    {
        var eventType = typeof(T);
        if (_eventHandlers.ContainsKey(eventType))
        {
            _eventHandlers[eventType].Remove(e => handler((T)e));
        }
    }

    public static void Publish(Event shipEvent)
    {
        var eventType = shipEvent.GetType();
        if (_eventHandlers.ContainsKey(eventType))
        {
            foreach (var handler in _eventHandlers[eventType])
            {
                handler(shipEvent);
            }
        }
    }
}