using Ship.Modules;
using Ship.Components;
using Ship.ShipConsole;
using Text = Ship.ShipConsole.Text;


namespace Ship.Views
{
    public static class MainBreakerView
    {

        public static void Render(this MainBreakerModule mainBreaker)
        {
            IsToggleableComponent toggleComponent = mainBreaker.GetComponent<IsToggleableComponent>();
            Box box = new Box(0, 0);
            Text text = new Text(GetBreakerStatus(toggleComponent.IsOn), 20, 10);
            box.Render();
            text.Render();
        }


        private static string GetBreakerStatus(bool breakerState)
        {
            return $"Main breaker is {(breakerState ? "*B**GREEN*ON" : "*B**RED**SWAP*OFF")}";
        }
    }
}
