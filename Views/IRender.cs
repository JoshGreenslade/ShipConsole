using Ship.Modules;

namespace Ship.Views;

public interface IRender
{
    public void Render(ShipModule module);
}