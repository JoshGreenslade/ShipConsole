using Ship.EventSystem;
using Ship.Entities;

namespace Ship.EventSystem;

public class ToggledEvent : Event
{
    public Entity entity;
    public bool State { get; }

    public ToggledEvent(Entity triggeringEntity, bool state)
    {
        entity = triggeringEntity;
        State = state;
    }

}

public class ToggleRequestEvent : Event
{
    public Entity entity { get; }

    public ToggleRequestEvent(Entity triggeringEntity)
    {
        entity = triggeringEntity;
    }
}