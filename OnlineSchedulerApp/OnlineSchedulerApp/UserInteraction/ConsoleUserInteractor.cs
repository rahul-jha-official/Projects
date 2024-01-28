namespace OnlineSchedulerApp.UserInteraction;

public class ConsoleUserInteractor : IUserInteractor
{
    private readonly ConsoleColor _defaultConsoleForegroundColor;
    public ConsoleUserInteractor()
    {
        _defaultConsoleForegroundColor = Console.ForegroundColor;
    }
    public void PrintError(string message)
    {
        PrintMessage(ConsoleColor.Red, message);
    }

    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void PrintSuccess(string message)
    {
        PrintMessage(ConsoleColor.Green, message);
    }

    public void PrintWarning(string message)
    {
        PrintMessage(ConsoleColor.Yellow, message);
    }

    private void PrintMessage(ConsoleColor color, string message)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ForegroundColor = _defaultConsoleForegroundColor;
    }
}
