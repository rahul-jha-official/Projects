namespace OnlineSchedulerApp.UserInteraction;

public interface IUserInteractor
{
    void PrintMessage(string message);
    void PrintError(string message);
    void PrintWarning(string message);
    void PrintSuccess(string message);
}