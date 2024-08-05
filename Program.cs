using Ship.Components;
using Ship.Entities;
using Ship.EventSystem;
using Ship.Modules;
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
        Console.Clear();
        Console.CursorVisible = false;

        MainBreakerView view = new MainBreakerView(mainBreaker);

        // Main loop
        Task renderTask = Task.Run(async () =>
        {
            while (true)
            {
                view.Render();
                await Task.Delay(25);
            }
        });

        Task inputTask = Task.Run(() =>
        {
            while (true)
            {
                Console.SetCursorPosition(0, Console.BufferHeight - 1);
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    isToggleableSystem.Toggle(mainBreaker);
                }
            }
        });

        await Task.WhenAll(renderTask, inputTask);
    }
}


// using Ship.ShipConsole;

// Console.Clear();
// Box box = new Box(0, 0);
// Text text = new Text("Main Breaker is: *B**GREEN*ON", 10, 10);
// Text text2 = new Text("Main Breaker is: *B**RED**SWAP*OFF", 10, 11);
// text.Render();
// text2.Render();
// while (true)
// {
//     box.Render();
//     Console.ReadKey();
//     box.Border = GetLetter();
// }

// char GetLetter()
// {
//     string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
//     Random rand = new Random();
//     int num = rand.Next(0, chars.Length);
//     return chars[num];
// }
