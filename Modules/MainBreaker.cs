namespace Ship.Modules;

using Ship.Entities;
using Ship.Components;

public class MainBreakerModule : ShipModule
{
    public MainBreakerModule()
    {
        this.AddComponent(new IsToggleableComponent(false));
    }
}
