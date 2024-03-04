using Budget_Tracking_App.Interfaces;

namespace Budget_Tracking_App.Services
{
    public class Logger
    {
        private static Logger instance;
        private static readonly object lockObject = new object();
        private ILogRepository logRepository;

        private Logger() { }

        public static Logger GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new Logger();
                    }
                }
            }
            return instance;
        }

        public void SetLogRepository(ILogRepository repository)
        {
            logRepository = repository;
        }

        public void Debug(string message)
        {
            logRepository.Log("DEBUG: " + message);
        }

        public void Error(string message)
        {
            logRepository.Log("ERROR: " + message);
        }

        public void Inform(string message)
        {
            logRepository.Log("INFO: " + message);
        }
    }
}
