using GameDataParserApp.Model;

namespace GameDataParserApp.DataAccess;

public interface IVideoGamesDeserializer
{
    List<VideoGame> DeserializeFrom(string fileName);
}
