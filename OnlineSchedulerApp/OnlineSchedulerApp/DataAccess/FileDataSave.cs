using OnlineSchedulerApp.Model;
using System.Text.Json;

namespace OnlineSchedulerApp.DataAccess;

public class FileDataSave<T> : IDataSave<T>
{
    private readonly StreamWriter writer;
    private readonly JsonSerializerOptions options;

    public FileDataSave(string filePath)
    {
        writer = new StreamWriter(filePath, false);
        options = new JsonSerializerOptions();
        options.WriteIndented = true;
    }

    public bool Save(IEnumerable<T> appointments)
    {
        try
        {
            var data = JsonSerializer.Serialize(appointments, options: options);
            writer.Write(data);
            writer.Flush();
            return true;
        }
        catch 
        {
            return false;
        }
    }

    public void Dispose()
    {
        writer.Dispose();
    }
}
