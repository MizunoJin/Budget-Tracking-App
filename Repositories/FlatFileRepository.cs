using Budget_Tracking_App.Interfaces;

namespace Budget_Tracking_App.Repositories
{
    public class FlatFileRepository : ILogRepository
    {
        private readonly string filePath = "logs/log.txt";

        public void Log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}
