
namespace Ship.ShipConsole;

public class Text
{
    public string _Text { get; set; } = string.Empty;
    public int Left = 0;
    public int Top = 0;
    public bool _rendering = false;

    public Text(string text, int left = 0, int top = 0)
    {
        _Text = text;
        Left = left;
        Top = top;
    }

    public void Update(string newText)
    {
        if (_Text.Length > newText.Length)
            newText = newText.PadRight(_Text.Length);
        _Text = newText;
    }

    public void Render()
    {
        _rendering = true;
        Console.SetCursorPosition(Left, Top);
        this.Write();
        _rendering = false;
    }
}