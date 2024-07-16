// using Ship.Components;
// using Ship.Entities;
// using Ship.EventSystem;
// using Ship.Modules;
// using Ship.Systems;
// using Ship.Views;
// using System;
// using System.Collections.Generic;
// using System.Threading;
// using System.Threading.Tasks;

// class Program
// {
//     static async Task Main(string[] args)
//     {
//         var powerSystem = new PowerSystem();
//         var isToggleableSystem = new IsToggleableSystem();

//         var mainBreaker = new MainBreakerModule();
//         var powerSource = new GenericPowerSource();

//         var powerDrain = new Entity();
//         powerDrain.AddComponent<IsToggleableComponent>(new IsToggleableComponent());
//         powerDrain.AddComponent<ConsumesPowerComponent>(new ConsumesPowerComponent(500));

//         // Set initial states
//         isToggleableSystem.SetState(mainBreaker, true);
//         isToggleableSystem.SetState(powerSource, true);
//         isToggleableSystem.SetState(powerDrain, true);

//         // Start the rendering task


//         // Main loop
//         while (true)
//         {
//             mainBreaker.Render();
//             isToggleableSystem.Toggle(mainBreaker);
//             Thread.Sleep(200);
//         }
//     }
// }

using System.Text;

void StatusUpdate()
{
    var whiteSpace = new StringBuilder();
    whiteSpace.Append(' ', 10);
    var random = new Random();
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    var randomWord = new string(Enumerable.Repeat(chars, random.Next(10)).Select(s => s[random.Next(s.Length)]).ToArray());
    while (true)
    {
        Console.SetCursorPosition(0, 0);
        var sb = new StringBuilder();
        sb.AppendLine($"<b>Program Status</b>:{whiteSpace}");
        sb.AppendLine("-------------------------------");
        sb.AppendLine($"Last Updated: {DateTime.Now.Millisecond}{whiteSpace}");
        sb.AppendLine($"Random Word: {randomWord}{whiteSpace}");
        sb.AppendLine("-------------------------------");
        sb.Replace("<b>", "\x1B[1m").Replace("</b>", "\x1B[0m");
        Console.Write(sb);
        Console.WriteLine("╔═╗");
        Console.WriteLine("╚═╝");
        randomWord = new string(Enumerable.Repeat(chars, random.Next(10)).Select(s => s[random.Next(s.Length)]).ToArray());
        Thread.Sleep(10);
    }
}

StatusUpdate();