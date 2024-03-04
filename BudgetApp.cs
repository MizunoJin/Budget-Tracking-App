using Budget_Tracking_App.Models;
using Budget_Tracking_App.Seeds;
using Budget_Tracking_App.Services;

namespace Budget_Tracking_App
{
    public class BudgetApp
    {
        private static BudgetApp _instance;
        private static readonly object _lock = new object();
        private static readonly Logger logger = Logger.GetInstance();

        private BudgetApp()
        {}

        public static BudgetApp GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new BudgetApp();
                    }
                }
            }
            return _instance;
        }

        public void Run()
        {
            // Make seed data for testing
            User user = SeedData.GetTestUser();
            Console.WriteLine($"Welcome {user.Name}!");
            logger.Info($"BudgetApp started for user {user.Name}.");

            bool exit = false;
            while (!exit)
            {
                DisplayMainMenu();
                exit = ProcessMainMenuOption(user);
            }
            logger.Info("BudgetApp session ended.");
        }

        private void DisplayMainMenu()
        {
            Console.WriteLine("Expense Tracker");
            Console.WriteLine("1. View Transactions");
            Console.WriteLine("2. Enter a Transaction");
            Console.WriteLine("3. Edit Transactions");
            Console.WriteLine("4. Delete Transactions");
            Console.WriteLine("5. View Categories");
            Console.WriteLine("6. Enter Categories");
            Console.WriteLine("7. Enter Budget");
            Console.WriteLine("8. Track Budget");
            Console.WriteLine("9. Exit");
            Console.Write("Select an option: ");
        }

        private bool ProcessMainMenuOption(User user)
        {
            Console.WriteLine();
            switch (Console.ReadLine())
            {
                case "1":
                    TransactionService.ViewTransactions(user);
                    break;
                case "2":
                    TransactionService.EnterTransaction(user);
                    break;
                case "3":
                    TransactionService.EditTransactions(user);
                    break;
                case "4":
                    TransactionService.DeleteTransactions(user);
                    break;
                case "5":
                    CategoryService.ViewCategories(user);
                    break;
                case "6":
                    CategoryService.EnterCategory(user);
                    break;
                case "7":
                    BudgetService.EnterBudget(user);
                    break;
                case "8":
                    BudgetService.TrackBudget(user);
                    break;
                case "9":
                    logger.Info("User chose to exit the application.");
                    return true;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    logger.Warn("User selected an invalid option.");
                    break;
            }
            Console.WriteLine();
            return false;
        }
    }
}
