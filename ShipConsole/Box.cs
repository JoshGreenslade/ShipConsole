namespace Ship.ShipConsole;

public class Box
{

    // Definitions
    public int Top;
    public int Left;
    public int Width;
    public int Height;

    // Location References
    public int CentreHeight => Top + (int)Math.Round(Height / 2.0);
    public int CentreWidth => Left + (int)Math.Round(Width / 2.0);

    // Stylising
    public char Border = '-';

    public Box(int left = 0, int top = 0, int? width = null, int? height = null)
    {
        Top = top;
        Left = left;
        if (width == null)
            Width = Console.BufferWidth - Left;
        else
            Width = (int)width;
        if (height == null)
            Height = Console.BufferHeight - Top;
        else
            Height = (int)height;
    }

    public void Render()
    {
        Console.SetCursorPosition(Left, Top);
        Console.Write(new string(Border, Width));
        Console.SetCursorPosition(Left, Top + Height);
        Console.Write(new string(Border, Width));
        for (int i = Top; i < Top + Height; i++)
        {
            Console.SetCursorPosition(Left, Top + i);
            Console.Write(Border);
            Console.SetCursorPosition(Left + Width - 1, Top + i);
            Console.Write(Border);
        }
    }
}