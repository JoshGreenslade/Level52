namespace Level52;

public class ConsoleInput : IUserInput
{
    public string GetInput()
    {
        return Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
    }
}