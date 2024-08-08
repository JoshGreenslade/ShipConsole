using Ship.Views;

namespace Ship.ShipConsole;

public class ShipConsole
{

    public IConsoleView _currentView;
    private int _refreshDelay;

    public ShipConsole(IConsoleView initialView, int refreshDelay = 250)
    {
        Console.CursorVisible = false;

        _refreshDelay = refreshDelay;
        SetView(initialView);
    }


    public void SetView(IConsoleView newView)
    {
        Console.Clear();
        _currentView = newView;
    }

    public async Task StartRenderingAsync()
    {
        while (true)
        {
            _currentView.Render();
            await Task.Delay(_refreshDelay);
        }
    }

    public async Task StartInputHandlingAsync()
    {
        while (true)
        {
            var key = Console.ReadKey(true);
            _currentView.HandleInput(key.Key);
            await Task.Delay(10);
        }
    }
}
