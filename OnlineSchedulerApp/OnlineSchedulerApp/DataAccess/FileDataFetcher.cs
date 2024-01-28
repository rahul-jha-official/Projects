using OnlineSchedulerApp.Model;
using System.Text.Json;

namespace OnlineSchedulerApp.DataAccess;

public class FileDataFetcher<T> : IDataFetcher<T>
{
    private readonly StreamReader reader; 
    public FileDataFetcher(string filePath)
    {
        reader = new StreamReader(filePath);
    }

    public IEnumerable<T> Fetch()
    {
        var data = reader.ReadToEnd();

        return JsonSerializer.Deserialize<IEnumerable<T>>(data);
    }

    public void Dispose()
    {
        reader.Dispose();
    }
}
