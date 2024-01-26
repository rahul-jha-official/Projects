using GameDataParserApp.Model;

namespace GameDataParserApp.UserInteraction;

public interface IGamesPrinter
{
    void Print(List<VideoGame> videoGames);
}
