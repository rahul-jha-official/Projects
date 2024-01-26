using GameDataParserApp.DataAccess;
using GameDataParserApp.UserInteraction;

namespace GameDataParserApp.App;

public class GameDataParserApp
{
    private readonly IUserInteractor _userInteractor;
    private readonly IGamesPrinter _gamesPrinter;
    private readonly IVideoGamesDeserializer _videoGamesDeserializer;

    public GameDataParserApp(
        IUserInteractor userInteractor,
        IGamesPrinter gamesPrinter,
        IVideoGamesDeserializer videoGamesDeserializer)
    {
        _userInteractor = userInteractor;
        _gamesPrinter = gamesPrinter;
        _videoGamesDeserializer = videoGamesDeserializer;
    }

    public void Run()
    {
        string fileName = _userInteractor.ReadValidFilePath();
        var videoGames = _videoGamesDeserializer.DeserializeFrom(fileName);
        _gamesPrinter.Print(videoGames);
    }
}
