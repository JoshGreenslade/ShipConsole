using System.Dynamic;

namespace Ship.ShipConsole;

public interface IRenderable
{
    public void Render();
    public bool RequiresRerender { get; set; }
}