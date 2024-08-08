using Ship.Components;
using Ship.Entities;
using Ship.Modules;
using Ship.ShipConsole;
using Ship.Systems;
using Ship.Views;


class Program
{
    static async Task Main(string[] args)
    {
        var powerSystem = new PowerSystem();
        var isToggleableSystem = new IsToggleableSystem();

        var mainBreaker = new MainBreakerModule();
        var powerSource = new GenericPowerSource();

        var powerDrain = new Entity();
        powerDrain.AddComponent<IsToggleableComponent>(new IsToggleableComponent());
        powerDrain.AddComponent<ConsumesPowerComponent>(new ConsumesPowerComponent(500));

        // Set initial states
        isToggleableSystem.SetState(mainBreaker, true);
        isToggleableSystem.SetState(powerSource, true);
        isToggleableSystem.SetState(powerDrain, true);

        // Start the rendering task
        MainBreakerView view = new MainBreakerView(mainBreaker);

        var shipConsole = new ShipConsole(view);

        Task renderTask = shipConsole.StartRenderingAsync();
        Task inputTask = shipConsole.StartInputHandlingAsync();

        await Task.WhenAll(renderTask, inputTask);

    }
}