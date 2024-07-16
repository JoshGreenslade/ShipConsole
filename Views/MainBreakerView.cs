using Ship.Modules;
using Ship.Components;
using Spectre.Console;


namespace Ship.Views
{
    public static class MainBreakerView
    {
        public static void Render(this MainBreakerModule mainBreaker)
        {
            var breakerComponent = mainBreaker.GetComponent<IsToggleableComponent>();

            var layout = new Layout("Root")
                .SplitColumns(
                    new Layout("Left"),
                    new Layout("Right")
                        .SplitRows(
                            new Layout("Top"),
                            new Layout("Bottom")));

            // Set initial content
            layout["Left"].Update(
                new Panel(
                    Align.Center(
                        new Markup(GetBreakerStatus(breakerComponent.IsOn)),
                        VerticalAlignment.Middle))
                    .Expand());
            AnsiConsole.Clear();
            AnsiConsole.Write(layout);
            var fruit = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("What's your [green]favorite fruit[/]?")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
        .AddChoices(new[] {
            "Apple", "Apricot", "Avocado",
            "Banana", "Blackcurrant", "Blueberry",
            "Cherry", "Cloudberry", "Cocunut",
        }));
        }

        private static string GetBreakerStatus(bool breakerState)
        {
            return $"Main breaker is {(breakerState ? "[bold green]ON[/]" : "[bold red]OFF[/]")}";
        }
    }
}
