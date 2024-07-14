using Ship.Components;
using Ship.Entities;
using Ship.EventSystem;

namespace Ship.Systems;

public class IsToggleableSystem : System
{
    public IsToggleableSystem() { }

    public void toggle(Entity entity)
    {
        if (!entity.HasComponent<IsToggleableComponent>())
            return;
        var component = entity.GetComponent<IsToggleableComponent>();
        component.IsOn = !component.IsOn;
        EventBus.Publish(new ToggledEvent(entity, component.IsOn));
    }

    public void setState(Entity entity, bool state)
    {
        if (!entity.HasComponent<IsToggleableComponent>())
            return;
        var component = entity.GetComponent<IsToggleableComponent>();
        component.IsOn = state;
        EventBus.Publish(new ToggledEvent(entity, component.IsOn));
    }
}