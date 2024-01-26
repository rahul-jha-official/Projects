using GameDataParserApp.Model;
using GameDataParserApp.UserInteraction;
using System.Text.Json;

namespace GameDataParserApp.DataAccess;

public class VideoGamesDeserializer : IVideoGamesDeserializer
{
    private readonly IFileReader _fileReader;
    private readonly IUserInteractor _userInteractor;
    public VideoGamesDeserializer(IFileReader fileReader, IUserInteractor userInteractor)
    {
        _fileReader = fileReader;
        _userInteractor = userInteractor;
    }
    public List<VideoGame> DeserializeFrom(string fileName)
    {
        string fileText = _fileReader.Read(fileName);

        try
        {
            return JsonSerializer.Deserialize<List<VideoGame>>(fileText);
        }
        catch (JsonException ex)
        {
            _userInteractor.PrintError($"JSON in {fileName} file was not " +
                $"in a Valid Format. JSON Body: " +
                $"{fileText}");
            throw new JsonException($"Unable to parse '{fileName}' as {nameof(VideoGame)} Data.", ex);
        }
    }
}
