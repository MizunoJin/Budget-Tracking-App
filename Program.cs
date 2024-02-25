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
            Console.WriteLine("3. Edit Transactions");
            Console.WriteLine("4. Delete Transactions");
            Console.WriteLine("5. View Categories");
            Console.WriteLine("6. Enter Budget");
            Console.WriteLine("7. Track Budget");
            Console.WriteLine("8. Exit");
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
                    EditTransactions(user);
                    break;
                case "4":
                    DeleteTransactions(user);
                    break;
                case "5":
                    ViewCategories(user);
                    break;
                case "6":
                    EnterBudget(user);
                    break;
                case "7":
                    TrackBudget(user);
                    break;
                case "8":
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

        List<PresetCategory> presetCategories = PresetCategory.GetInstances();
        List<UserCategory> userCategories = user.UserCategoryList;
        List<Category> categories = presetCategories.Cast<Category>().Concat(userCategories.Cast<Category>()).ToList();

        // Display categories
        Console.WriteLine("Please select a category by entering the corresponding number:");
        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {categories[i].Name}");
        }

        // User selects a category
        int choice = Convert.ToInt32(Console.ReadLine()) - 1;

        Category category = null;

        if (choice >= 0 && choice < categories.Count)
        {
            category = categories[choice];
            Console.WriteLine($"You selected: {category.Name}");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }

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

    static void EditTransactions(User user)
    {
        Console.WriteLine("Edit transaction details");
        Console.Write("Enter Transaction ID to edit: ");
        int transactionId = int.Parse(Console.ReadLine());

        var transactionToEdit = user.TransactionList.FirstOrDefault(t => t.TransactionId == transactionId);

        if (transactionToEdit == null)
        {
            Console.WriteLine("Transaction not found.");
            return;
        }

        Console.Write("New Date (yyyy-MM-dd) or press Enter to skip: ");
        var dateInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(dateInput))
        {
            transactionToEdit.TransactionDate = DateOnly.Parse(dateInput);
        }

        Console.Write("New Type (Income/Expense) or press Enter to skip: ");
        var typeInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(typeInput))
        {
            transactionToEdit.Type = (Transaction.TransactionType)Enum.Parse(typeof(Transaction.TransactionType), typeInput, true);
        }

        Console.Write("Is Recurring (true/false) or press Enter to skip: ");
        var recurringInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(recurringInput))
        {
            transactionToEdit.IsRecurring = bool.Parse(recurringInput);
        }

        Console.Write("New Note or press Enter to skip: ");
        var noteInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(noteInput))
        {
            transactionToEdit.Note = noteInput;
        }

        Console.Write("New Amount or press Enter to skip: ");
        var amountInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(amountInput))
        {
            transactionToEdit.TransactionAmount = double.Parse(amountInput);
        }

        List<PresetCategory> presetCategories = PresetCategory.GetInstances();
        List<UserCategory> userCategories = user.UserCategoryList;
        List<Category> categories = presetCategories.Cast<Category>().Concat(userCategories.Cast<Category>()).ToList();

        // Display categories
        Console.WriteLine("Please select a category by entering the corresponding number:");
        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {categories[i].Name}");
        }

        // User selects a category
        int choice = Convert.ToInt32(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < categories.Count)
        {
            transactionToEdit.Category = categories[choice];
            Console.WriteLine($"You selected: {categories[choice].Name}");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }

        Console.WriteLine("Transaction updated successfully.");
    }

    static void DeleteTransactions(User user)
    {
        Console.WriteLine("Enter the Transaction ID to delete:");
        int transactionId = int.Parse(Console.ReadLine());

        // トランザクションをIDで検索
        var transaction = user.TransactionList.FirstOrDefault(t => t.TransactionId == transactionId);

        if (transaction != null)
        {
            // トランザクションが見つかった場合、リストから削除
            user.TransactionList.Remove(transaction);
            Console.WriteLine("Transaction deleted successfully.");
        }
        else
        {
            // トランザクションが見つからなかった場合、メッセージを表示
            Console.WriteLine("Transaction not found.");
        }
    }

    static void ViewCategories(User user)
    {
        List<PresetCategory> presetCategories = PresetCategory.GetInstances();
        List<UserCategory> userCategories = user.UserCategoryList;
        List<Category> categories = presetCategories.Cast<Category>().Concat(userCategories.Cast<Category>()).ToList();

        foreach (var category in categories)
        {
            Console.WriteLine($"Category ID: {category.CategoryId}");
            Console.WriteLine($"Name: {category.Name}");
            Console.WriteLine($"Opening Date: {category.OpeningDate}");
            Console.WriteLine($"Budget Allocated: {category.BudgetAllocated}");
            Console.WriteLine($"Balance: {category.Balance}");
            Console.WriteLine("------------------------------");
        }
    }

    static void EnterBudget(User user)
    {
        // Implementation to enter a budget
    }

    static void TrackBudget(User user)
    {
        // Implementation to track budget
    }
}
