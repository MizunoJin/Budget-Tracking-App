using Budget_Tracking_App.Repositories;
using Budget_Tracking_App.Services;

namespace Budget_Tracking_App;

class Program
{
    static void Main(string[] args)
    {
        Logger logger = Logger.GetInstance();
        string environment = Environment.GetEnvironmentVariable("APP_ENVIRONMENT") ?? "development";

        if (environment == "development")
        {
            // Use FlatFileRepository in development
            logger.SetLogRepository(new FlatFileRepository());
            logger.Info("Logging to console in development environment.");
        }
        else
        {
            // Use DatabaseRepository in other environments
            logger.SetLogRepository(new DatabaseRepository());
            logger.Info("Logging to database in non-development environment.");
        }

        var app = BudgetApp.GetInstance();
        app.Run();
        logger.Info("Application has finished running.");
    }
}


