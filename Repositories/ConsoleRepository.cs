using Budget_Tracking_App.Interfaces;

namespace Budget_Tracking_App.Repositories
{
    public class ConsoleRepository : ILogRepository
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
