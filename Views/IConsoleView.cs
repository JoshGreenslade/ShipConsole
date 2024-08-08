namespace Ship.Views;

public interface IConsoleView
{
    void Render();
    void HandleInput(ConsoleKey key);
}