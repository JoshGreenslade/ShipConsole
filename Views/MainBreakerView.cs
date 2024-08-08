using Ship.Modules;
using Ship.Components;
using Ship.ShipConsole;
using Text = Ship.ShipConsole.Text;
using Ship.EventSystem;


namespace Ship.Views
{
    public class MainBreakerView : IConsoleView
    {

        private MainBreakerModule _module;
        private Text _text;
        private Box _mainBox;
        private Box _menuBox;
        private static int _menuBoxWidth = (int)((double)Console.BufferWidth / 4.0);

        private IsToggleableComponent toggle => _module.GetComponent<IsToggleableComponent>();

        public MainBreakerView(MainBreakerModule module)
        {
            _module = module;

            _menuBox = new Box(left: 0, top: 0, width: _menuBoxWidth);
            _mainBox = new Box(left: _menuBoxWidth - 1, top: 0);
            _text = new Text(GetBreakerStatus(), _mainBox.CentreWidth, _mainBox.CentreHeight);
            _text.alignment = TextAlignment.Centre;

            _menuBox.RequiresRerender = true;
            _mainBox.RequiresRerender = true;
            _text.RequiresRerender = true;

        }

        public void Render()
        {
            _text.Update(GetBreakerStatus());

            foreach (var item in new List<IRenderable> { _menuBox, _mainBox, _text })
            {
                if (item.RequiresRerender)
                    item.Render();

            }
        }

        public void HandleInput(ConsoleKey key)
        {
            if (key == ConsoleKey.Enter)
            {
                EventBus.Publish(new ToggleRequestEvent(_module));
                _text.RequiresRerender = true;
            }
        }

        private string GetBreakerStatus()
        {
            IsToggleableComponent toggleComponent = _module.GetComponent<IsToggleableComponent>();
            bool breakerState = toggleComponent.IsOn;
            return $"Main breaker is {(breakerState ? "*B**GREEN*ON" : "*B**RED**SWAP*OFF")}";
        }
    }
}
