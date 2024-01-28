namespace OnlineSchedulerApp.Model;

public class SlotDetail
{
    public string Name { get; init; }
    public int Start { get; init; }
    public int End { get; set; }

    public override string ToString()
    {
        return $"{Start}.\t{Name}";
    }
}
