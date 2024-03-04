using Budget_Tracking_App.Interfaces;

namespace Budget_Tracking_App.Repositories
{
    public class DatabaseRepository : ILogRepository
    {
        public void Log(string message)
        {
            // TODO: Implement logging to a database
            Console.WriteLine("Logging to database: " + message);
        }
    }
}
