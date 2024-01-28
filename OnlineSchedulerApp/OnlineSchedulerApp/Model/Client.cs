namespace OnlineSchedulerApp.Model;

public class Client
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }

    public override string ToString()
    {
        return $"[Id: {Id}, Name: {Name}, Email: {Email}]";
    }
}
