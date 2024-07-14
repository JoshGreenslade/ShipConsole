using System.ComponentModel;

namespace Ship.Entities;

public class Entity
{
    public Guid id = Guid.NewGuid();
    private Dictionary<Type, object> _components = new Dictionary<Type, object>();

    public void AddComponent<T>(T component)
    {
        _components[typeof(T)] = component;
    }

    public T GetComponent<T>()
    {
        return (T)_components[typeof(T)];
    }

    public bool HasComponent<T>()
    {
        return _components.ContainsKey(typeof(T));
    }
}