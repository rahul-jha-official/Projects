namespace OnlineSchedulerApp.Model;

public class ServiceOperator
{
    public int Id { get; init; }
    public string Name { get; init; }

    public override string ToString()
    {
        return $"{Id}. {Name}";
    }
}
