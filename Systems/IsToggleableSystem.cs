using Ship.Components;
using Ship.Entities;
using Ship.EventSystem;

namespace Ship.Systems;

public class IsToggleableSystem : System
{
    public IsToggleableSystem()
    {
        EventBus.Subscribe<ToggleRequestEvent>(OnToggleRequest);
    }

    public void OnToggleRequest(ToggleRequestEvent toggleRequestEvent)
    {
        var entity = toggleRequestEvent.entity;
        if (!entity.HasComponent<IsToggleableComponent>())
            return;
        var component = entity.GetComponent<IsToggleableComponent>();
        component.IsOn = !component.IsOn;
        EventBus.Publish(new ToggledEvent(entity, component.IsOn));
    }

    public void SetState(Entity entity, bool state)
    {
        if (!entity.HasComponent<IsToggleableComponent>())
            return;
        var component = entity.GetComponent<IsToggleableComponent>();
        component.IsOn = state;
        EventBus.Publish(new ToggledEvent(entity, component.IsOn));
    }
}