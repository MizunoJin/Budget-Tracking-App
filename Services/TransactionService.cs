using Budget_Tracking_App.Models;

namespace Budget_Tracking_App.Services
{
    public class TransactionService
    {
        private static readonly Logger logger = Logger.GetInstance();

        public static void ViewTransactions(User user)
        {
            logger.Debug($"Viewing transactions for user {user.Name}.");

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

            logger.Info($"Transactions viewed for user {user.Name}.");
        }

        public static void EnterTransaction(User user)
        {
            logger.Debug($"Entering transaction for user {user.Name}.");
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

            List<Category> categories = user.GetCategories();

            CategoryService.DisplayCategories(categories);

            var category = CategoryService.SelectCategory(categories);

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
            logger.Info($"Transaction added for user {user.Name}.");
        }

        public static void EditTransactions(User user)
        {
            logger.Debug($"Editing transaction for user {user.Name}.");
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

            List<Category> categories = user.GetCategories();

            CategoryService.DisplayCategories(categories);

            transactionToEdit.Category = CategoryService.SelectCategory(categories);

            Console.WriteLine("Transaction updated successfully.");
            logger.Info($"Transaction updated for user {user.Name}.");
        }

        public static void DeleteTransactions(User user)
        {
            logger.Debug($"Deleting transaction for user {user.Name}.");
            Console.WriteLine("Enter the Transaction ID to delete:");
            int transactionId = int.Parse(Console.ReadLine());

            var transaction = user.TransactionList.FirstOrDefault(t => t.TransactionId == transactionId);

            if (transaction != null)
            {
                user.TransactionList.Remove(transaction);
                Console.WriteLine("Transaction deleted successfully.");
                logger.Info($"Transaction deleted for user {user.Name}.");
            }
            else
            {
                Console.WriteLine("Transaction not found.");
            }
        }
    }
}
