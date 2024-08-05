using Ship.Modules;
using Ship.Components;
using Ship.ShipConsole;
using Text = Ship.ShipConsole.Text;


namespace Ship.Views
{
    public class MainBreakerView
    {

        private ShipModule _module;
        private Text _text;
        private Box _box;

        public MainBreakerView(ShipModule module)
        {
            _module = module;

            IsToggleableComponent toggleComponent = _module.GetComponent<IsToggleableComponent>();
            _box = new Box(0, 0, height: Console.BufferHeight - 2);
            _text = new Text(GetBreakerStatus(), 20, 10);

            _box.Render();

        }

        public void Render()
        {
            _text.Update(GetBreakerStatus());
            _text.Render();
        }


        private string GetBreakerStatus()
        {
            IsToggleableComponent toggleComponent = _module.GetComponent<IsToggleableComponent>();
            bool breakerState = toggleComponent.IsOn;
            return $"Main breaker is {(breakerState ? "*B**GREEN*ON" : "*B**RED**SWAP*OFF")}";
        }
    }
}
