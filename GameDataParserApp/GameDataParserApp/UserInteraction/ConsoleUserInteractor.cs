namespace GameDataParserApp.UserInteraction;

public class ConsoleUserInteractor : IUserInteractor
{
    public void PrintError(string message)
    {
        var currentForegroundColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        PrintMessage(message);
        Console.ForegroundColor = currentForegroundColor;
    }

    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void PrintWarning(string message)
    {
        var currentForegroundColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        PrintMessage(message);
        Console.ForegroundColor = currentForegroundColor;
    }

    public string ReadValidFilePath()
    {
        var filePath = default(string);
        do
        {
            PrintMessage("Enter the name of the file you want to read: ");
            filePath = Console.ReadLine();

            if (filePath is null)
            {
                PrintWarning("The file name cannot be null.");
            }
            else if (string.Equals(filePath,string.Empty))
            {
                PrintWarning("The file name cannot be empty.");
            }
            else if (!File.Exists(filePath))
            {
                PrintWarning("The file does not exist.");
            }
            else
            {
                break;
            }
        } while (true);

        return filePath;
    }
}
