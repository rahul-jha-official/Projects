using OnlineSchedulerApp.DataAccess;
using OnlineSchedulerApp.Model;

namespace OnlineSchedulerApp.UserInteraction;

public class HomePage : IDisposable
{
    private readonly IDataSave<Client> _clientSave;
    private readonly IDataSave<Appointment> _appointmentSave;

    private readonly Slots _slots;
    private IUserInteractor _userInteractor;
    private List<ServiceOperator> _operators;
    private List<Appointment> _appointments;
    private List<Client> _clients;
    private Client _client;

    public HomePage(List<Client> clients,
        List<ServiceOperator> operators,
        List<Appointment> appointments,
        IDataSave<Client> clientSave,
        IDataSave<Appointment> appointmentSave,
        IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;

        _clientSave = clientSave;
        _appointmentSave = appointmentSave;

        _slots = new Slots();

        _clients = clients;
        _operators = operators;
        _appointments = appointments;
    }

    public void Run()
    {
        _userInteractor.PrintMessage("Hello Everyone,\nWelcome to the online scheduler simulation");
        LoginSignupPage();
    }

    public void LoginSignupPage()
    {
        _userInteractor.PrintMessage("***************************************************");
        _userInteractor.PrintMessage("Please select from below");
        _userInteractor.PrintMessage("1. Login");
        _userInteractor.PrintMessage("2. SignUp");
        _userInteractor.PrintMessage("3. Exit");
        _userInteractor.PrintMessage("Your Choice: ");

        var input = Console.ReadLine();

        int choice;

        if(!int.TryParse(input, out choice))
        {
            throw new Exception("Invalid Choice!!");
        }

        switch (choice)
        {
            case 1: 
                Login();
                break;
            case 2:
                Singup();
                break;
            case 3:
                return;
            default: throw new Exception("Invalid Choice!!");
        }
        Menu();
    }

    public void Login()
    {
        _userInteractor.PrintMessage("Enter Your Details");
        _userInteractor.PrintMessage("Enter Email:");
        var input = Console.ReadLine();

        _client = _clients.First(e => string.Equals(e.Email, input, StringComparison.OrdinalIgnoreCase));

        if (_client is null)
        {
            throw new Exception("User Not Found!!");
        }
        else
        {
            _userInteractor.PrintSuccess("Login Successful!" +
                $"Welcome {_client.Name}");
        }
    }

    public void Singup()
    {
        _userInteractor.PrintMessage("Enter Your Details");
        _userInteractor.PrintMessage("Enter Name:");
        var name = Console.ReadLine();
        _userInteractor.PrintMessage("Enter Email:");
        var email = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
        {
            throw new Exception("Invalid Name/Email!!");
        }

        var id = _clients.Count() + 1;

        _client = new Client
        {
            Id = id,
            Name = name,
            Email = email
        };

        _clients.Add(_client);
    }

    public void Menu()
    {
        _userInteractor.PrintMessage("Please select from below");
        _userInteractor.PrintMessage("1. Book an Appointment");
        _userInteractor.PrintMessage("2. Cancel an existing appointment");
        _userInteractor.PrintMessage("3. Reschedule an existing Appointment");
        _userInteractor.PrintMessage("4. Show Booked Appointment of an Operator");
        _userInteractor.PrintMessage("5. Show Open Slot of Operator");
        _userInteractor.PrintMessage("6. Exit");
        _userInteractor.PrintMessage("Your Choice: ");

        var input = Console.ReadLine();

        int choice;

        if (!int.TryParse(input, out choice))
        {
            throw new Exception("Invalid Choice!!");
        }

        switch (choice)
        {
            case 1:
                BookAppointment();
                break;
            case 6:
                return;
            default: throw new Exception("Invalid Choice!!");
        }
    }

    public void BookAppointment()
    {
        _userInteractor.PrintMessage("Please Select Operator From Below");
        foreach (var @operator in _operators)
        {
            _userInteractor.PrintMessage(@operator.ToString());
        }
        _userInteractor.PrintMessage("-1\tAny Operator");
        _userInteractor.PrintMessage("Please Choose Operator Id: ");

        var input = Console.ReadLine();

        int choice;

        if (!int.TryParse(input, out choice))
        {
            throw new Exception("Invalid Choice!!");
        }

        var op = _operators.FirstOrDefault(e => choice == -1
                    || e.Id == choice);

        if (op is null)
        {
            throw new Exception("No Operator found!!");
        }

        _userInteractor.PrintSuccess($"Operator {op.Name}, Selected");

        var date = DateOnly.FromDateTime(DateTime.Now.AddDays(2));

        var availableSlots = _slots.All.Where(s => 
                !_appointments.Where(a => a.Date == date 
                    && a.Operator.Id == op.Id 
                    && a.Status == AppintmentStatus.Booked)
                .Select(a => a.Slot.Start).Contains(s.Start));

        _userInteractor.PrintMessage("Available Slots of the Operator are:  ");

        foreach (var slot in availableSlots)
        {
            _userInteractor.PrintMessage(slot.ToString());
        }

        _userInteractor.PrintMessage("Please Select Slot From Above");

        input = Console.ReadLine();

        if (!int.TryParse(input, out choice))
        {
            throw new Exception("Invalid Choice!!");
        }

        var selectedSlot = _slots.FindSlot(choice);

        var appointment = new Appointment
        {
            Id = _appointments.Count + 1,
            Operator = op,
            Client = _client,
            Date = date,
            Slot = selectedSlot,
            Status = AppintmentStatus.Booked
        };

        _appointments.Add(appointment);
    }

    public void Dispose()
    {
        _clientSave.Save(_clients);
        _appointmentSave.Save(_appointments);
    }
}
