using GameDataParserApp.DataAccess;
using GameDataParserApp.Logging;
using GameDataParserApp.UserInteraction;

IFileReader reader = new LocalFileReader();
IUserInteractor userInteractor = new ConsoleUserInteractor();
IGamesPrinter gamesPrinter = new GamesPrinter(userInteractor);
IVideoGamesDeserializer videoGamesDeserializer = new VideoGamesDeserializer(
                        reader, 
                        userInteractor);


var app = new GameDataParserApp.App.GameDataParserApp(
                        userInteractor, 
                        gamesPrinter, 
                        videoGamesDeserializer);

var logger = new Logger("log.txt");

try
{
    app.Run();
}
catch (Exception ex)
{
    userInteractor.PrintWarning("Sorry! The application has experienced an unexpected error " +
        "and will have to be closed.");
    logger.Log(ex);
}

userInteractor.PrintMessage("Press any key to close.");
Console.ReadKey();