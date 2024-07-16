namespace Ship.Modules;

using Ship.Entities;
using Ship.Views;
using Ship.Components;

public class GenericPowerSource : ShipModule
{

    public double PowerGeneration = 1000;

    public GenericPowerSource()
    {
        this.AddComponent(new IsToggleableComponent(false));
        this.AddComponent(new GeneratesPowerComponent(PowerGeneration));
    }
}
