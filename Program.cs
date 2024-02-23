using Budget_Tracking_App.Models;
using Budget_Tracking_App.Seeds;

namespace Budget_Tracking_App;

class Program
{
    static void Main(string[] args)
    {
        User user = SeedData.GetTestUser();
        Console.WriteLine($"Welcome {user.Name}!");

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Expense Tracker");
            Console.WriteLine("1. View Transactions");
            Console.WriteLine("2. Enter a Transaction");
            Console.WriteLine("3. Edit/Delete Transactions");
            Console.WriteLine("4. View Categories");
            Console.WriteLine("5. Enter Budget");
            Console.WriteLine("6. Track Budget");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ViewTransactions(user);
                    break;
                case "2":
                    EnterTransaction(user);
                    break;
                case "3":
                    EditDeleteTransactions();
                    break;
                case "4":
                    ViewCategories();
                    break;
                case "5":
                    EnterBudget();
                    break;
                case "6":
                    TrackBudget();
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }

    static void ViewTransactions(User user)
    {
        foreach (var transaction in user.TransactionList)
        {
            Console.WriteLine($"Transaction ID: {transaction.TransactionId}");
            Console.WriteLine($"Date: {transaction.TransactionDate}");
            Console.WriteLine($"Type: {transaction.Type}");
            Console.WriteLine($"Recurring: {transaction.IsRecurring}");
            Console.WriteLine($"Note: {transaction.Note}");
            Console.WriteLine($"Amount: {transaction.TransactionAmount}");
            Console.WriteLine($"Category: {transaction.Category.Name}");
            Console.WriteLine("------------------------------");
        }
    }

    static void EnterTransaction(User user)
    {
        Console.WriteLine("Enter transaction details");

        Console.Write("Date (yyyy-MM-dd): ");
        DateOnly transactionDate = DateOnly.Parse(Console.ReadLine());

        Console.Write("Type (Income/Expense): ");
        Transaction.TransactionType type = (Transaction.TransactionType)Enum.Parse(typeof(Transaction.TransactionType), Console.ReadLine(), true);

        Console.Write("Is Recurring (true/false): ");
        bool isRecurring = bool.Parse(Console.ReadLine());

        Console.Write("Note: ");
        string note = Console.ReadLine();

        Console.Write("Amount: ");
        double amount = double.Parse(Console.ReadLine());

        // カテゴリの例ですが、実際のアプリケーションでは、ユーザーが選択するまたは入力するリストから選択します。
        Console.Write("Category (Food, Utilities, Entertainment, etc.): ");
        Category category = new Category { Name = Console.ReadLine() }; // 仮のカテゴリオブジェクト作成

        Transaction newTransaction = new Transaction
        {
            TransactionDate = transactionDate,
            Type = type,
            IsRecurring = isRecurring,
            Note = note,
            TransactionAmount = amount,
            Category = category,
            User = user
        };

        user.TransactionList.Add(newTransaction);
        Console.WriteLine("Transaction added successfully.");
    }

    static void EditDeleteTransactions()
    {
        // Implementation to edit or delete transactions
    }

    static void ViewCategories()
    {
        // Implementation to view categories
    }

    static void EnterBudget()
    {
        // Implementation to enter a budget
    }

    static void TrackBudget()
    {
        // Implementation to track budget
    }
}
