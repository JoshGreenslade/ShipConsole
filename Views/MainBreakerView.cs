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
        private Box _mainBox;
        private Box _menuBox;
        private static int _menuBoxWidth = (int)((double)Console.BufferWidth / 4.0);

        public MainBreakerView(ShipModule module)
        {
            _module = module;

            IsToggleableComponent toggleComponent = _module.GetComponent<IsToggleableComponent>();
            _menuBox = new Box(left: 0, top: 0, width: _menuBoxWidth);
            _mainBox = new Box(left: _menuBoxWidth - 1, top: 0);
            _text = new Text(GetBreakerStatus(), _mainBox.CentreWidth, _mainBox.CentreHeight);
            _text.alignment = TextAlignment.Centre;

            _menuBox.Render();
            _mainBox.Render();

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
