namespace Level52.Utils;

public static class ServiceLocator
{
    private static IUserInput _userInput;
    private static IDisplay _display;
    private static Random _rng;

    public static Random Rng
    {
        get => _rng ?? throw new InvalidOperationException("IUserInput has not yet been set");
        set => _rng = value;
    }
    public static IUserInput UserInput
    {
        get => _userInput ?? throw new InvalidOperationException("IUserInput has not yet been set");
        set => _userInput = value;
    }
    
    public static IDisplay Display
    {
        get => _display ?? throw new InvalidOperationException("IDisplay has not yet been set");
        set => _display = value;
    }
}