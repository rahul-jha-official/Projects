using OnlineSchedulerApp.DataAccess;
using OnlineSchedulerApp.Model;
using OnlineSchedulerApp.UserInteraction;

namespace OnlineSchedulerApp.App;

public class OnlineScheduler
{
    

    public OnlineScheduler(IDataFetcher<Client> clientFetcher,
        IDataFetcher<ServiceOperator> operatorFetcher,
        IDataFetcher<Appointment> appointmentFetcher,
        IUserInteractor userInteractor)
    {
        //_userInteractor = userInteractor;
    }

    public void Run()
    {
        
    }

    
}
