namespace OnlineSchedulerApp.Model;

public class Appointment
{
    public int Id { get; init; }
    public Client Client { get; init; }
    public ServiceOperator Operator { get; init; }
    public SlotDetail Slot { get; init; }
    public DateOnly Date { get; set; }
    public AppintmentStatus Status { get; set; }
}
