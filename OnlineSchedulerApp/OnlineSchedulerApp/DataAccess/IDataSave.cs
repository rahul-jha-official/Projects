using OnlineSchedulerApp.Model;

namespace OnlineSchedulerApp.DataAccess;

public interface IDataSave<T> : IDisposable
{
    bool Save(IEnumerable<T> appointments);
}
