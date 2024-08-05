
namespace Ship.ShipConsole;

public enum TextAlignment
{
    Left,
    Right,
    Centre
}

public class Text
{
    // Definitions
    public string _Text { get; set; } = string.Empty;
    public int Left = 0;
    public int Top = 0;
    public bool _rendering = false;

    // Stylising
    public TextAlignment alignment { get; set; } = TextAlignment.Left;

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
        if (alignment == TextAlignment.Left)
        {
            Console.SetCursorPosition(Left, Top);
        }
        else if (alignment == TextAlignment.Centre)
        {
            Console.SetCursorPosition(Left - _Text.Length / 2, Top);
        }
        else if (alignment == TextAlignment.Right)
        {
            Console.SetCursorPosition(Left - _Text.Length, Top);
        }
        this.Write();
        Console.SetCursorPosition(0, Console.BufferHeight - 1);
        _rendering = false;
    }
}