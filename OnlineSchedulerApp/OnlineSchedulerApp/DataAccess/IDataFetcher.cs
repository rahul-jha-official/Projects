namespace OnlineSchedulerApp.DataAccess
{
    public interface IDataFetcher<T> : IDisposable
    {
        IEnumerable<T> Fetch();
    }
}
