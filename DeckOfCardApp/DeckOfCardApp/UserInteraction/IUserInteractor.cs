namespace DeckOfCardApp.UserInteraction;

public interface IUserInteractor
{
    void PrintMessage(string message);
    void PrintWarning(string message);
    void PrintError(string message);
    void PrintSuccessMessage(string message);
}
