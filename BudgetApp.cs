using Budget_Tracking_App.Models;
using Budget_Tracking_App.Services;

namespace Budget_Tracking_App
{
    public class BudgetApp
    {
        private readonly User _user;

        public BudgetApp(User user)
        {
            _user = user;
        }

        public void Run()
        {
            Console.WriteLine($"Welcome {_user.Name}!");

            bool exit = false;
            while (!exit)
            {
                DisplayMainMenu();
                exit = ProcessMainMenuOption();
            }
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

        private bool ProcessMainMenuOption()
        {
            Console.WriteLine();
            switch (Console.ReadLine())
            {
                case "1":
                    TransactionService.ViewTransactions(_user);
                    break;
                case "2":
                    TransactionService.EnterTransaction(_user);
                    break;
                case "3":
                    TransactionService.EditTransactions(_user);
                    break;
                case "4":
                    TransactionService.DeleteTransactions(_user);
                    break;
                case "5":
                    CategoryService.ViewCategories(_user);
                    break;
                case "6":
                    CategoryService.EnterCategory(_user);
                    break;
                case "7":
                    BudgetService.EnterBudget(_user);
                    break;
                case "8":
                    BudgetService.TrackBudget(_user);
                    break;
                case "9":
                    return true;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
            Console.WriteLine();
            return false;
        }
    }
}
