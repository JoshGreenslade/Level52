namespace Level52;

public class ConsoleDisplay : IDisplay
{

    public void WriteLine(string text = "")
    {
        Console.WriteLine(text);
    }
    
    public void Write(string text = "")
    {
        Console.Write(text);
    }
}