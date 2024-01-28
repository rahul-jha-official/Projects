using OnlineSchedulerApp.App;
using OnlineSchedulerApp.Config;
using OnlineSchedulerApp.DataAccess;
using OnlineSchedulerApp.Model;
using OnlineSchedulerApp.UserInteraction;

var config = new FileConfig();

List<Client> clients = new();
List<ServiceOperator> operators = new();
List<Appointment> appointments = new();

using (IDataFetcher<Client> clientFetcher = new FileDataFetcher<Client>(config.Client))
{
    clients = clientFetcher.Fetch().ToList();
}
using (IDataFetcher<ServiceOperator> operatorFetcher = new FileDataFetcher<ServiceOperator>(config.ServiceOperator))
{
    operators = operatorFetcher.Fetch().ToList();
}
using (IDataFetcher<Appointment> appointmentFetcher = new FileDataFetcher<Appointment>(config.Appointment))
{
    appointments = appointmentFetcher.Fetch().ToList();
}


using IDataSave<Client> clientSave = new FileDataSave<Client>(config.Client);
using IDataSave<Appointment> appointmentSave = new FileDataSave<Appointment>(config.Appointment);

using var x = new HomePage(clients, operators, appointments, clientSave, appointmentSave, new ConsoleUserInteractor());
x.Run();

Console.ReadKey();