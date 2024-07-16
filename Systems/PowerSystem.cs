using Ship.Components;
using Ship.Entities;
using Ship.EventSystem;

namespace Ship.Systems;

public class PowerSystem : System
{
    public double TotalPower;
    public double AvailablePower;

    public PowerSystem()
    {
        EventBus.Subscribe<ToggledEvent>(handlePowerSourceToggled);
        EventBus.Subscribe<ToggledEvent>(handlePowerConsumerToggled);
    }

    public void handlePowerSourceToggled(ToggledEvent toggledEvent)
    {
        Entity entity = toggledEvent.entity;

        if (!entity.HasComponent<GeneratesPowerComponent>())
            return;

        GeneratesPowerComponent component = entity.GetComponent<GeneratesPowerComponent>();
        if (toggledEvent.State == true)
        {
            component.currentPower = component.maxPower;
            TotalPower += component.currentPower;
            AvailablePower += component.currentPower;
        }
        else if (toggledEvent.State == false)
        {
            component.currentPower = 0;
            TotalPower -= component.currentPower;
            AvailablePower -= component.currentPower;
        }
    }

    public void handlePowerConsumerToggled(ToggledEvent toggledEvent)
    {
        Entity entity = toggledEvent.entity;
        if (!entity.HasComponent<ConsumesPowerComponent>())
            return;

        ConsumesPowerComponent component = entity.GetComponent<ConsumesPowerComponent>();
        if (toggledEvent.State == true)
        {
            if (AvailablePower > component.maxPowerDraw)
            {
                component.currentPowerDraw = component.maxPowerDraw;
                AvailablePower -= component.maxPowerDraw;
            }
            else if (AvailablePower < component.maxPowerDraw)
            {
                component.currentPowerDraw = AvailablePower;
                AvailablePower -= component.currentPowerDraw;
            }

        }
        else if (toggledEvent.State == false)
        {
            AvailablePower += component.currentPowerDraw;
            component.currentPowerDraw = 0;
        }
    }
}