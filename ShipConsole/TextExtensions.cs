namespace Ship.ShipConsole;

public static class TextExtensions
{
    private static readonly Dictionary<string, string> validTextFormatCommands = new()
    {
        { "*U*", "\x1B[4m" },
        { "*/U*", "\x1B[24m" },
        { "*B*", "\x1B[1m" },
        { "*/B*", "\x1B[22m" },
        { "*RED*", "\x1B[31m" },
        { "*GREEN*", "\x1B[32m" },
        { "*SWAP*", "\x1B[7m" },
        { "*RESET*", "\x1B[0m" },
    };

    public static void Write(this Text text)
    {
        string myText = text._Text;
        foreach (string key in validTextFormatCommands.Keys)
        {
            myText = myText.Replace(key, validTextFormatCommands[key]);
        }
        myText += validTextFormatCommands["*RESET*"];
        // myText.PadRight();
        Console.Write(myText);
    }


}