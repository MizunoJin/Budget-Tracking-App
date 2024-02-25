using Budget_Tracking_App.Models;

namespace Budget_Tracking_App.Seeds
{
    public class SeedData
    {
        public static User GetTestUser()
        {
            // Initialize categories
            var groceries = new PresetCategory { Name = "Groceries", TransactionList = new List<Transaction>() };
            var utilities = new PresetCategory { Name = "Utilities", TransactionList = new List<Transaction>()  };
            var salary = new PresetCategory { Name = "Salary", TransactionList = new List<Transaction>()  };
            var entertainment = new PresetCategory { Name = "Entertainment", TransactionList = new List<Transaction>()  };

            // Initialize user with transactions
            var user = new User
            {
                UserId = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                TransactionList = new List<Transaction>(),
                UserCategoryList = new List<UserCategory>()
            };

            // Initialize transactions
            var transactions = new List<Transaction>
        {
            new Transaction
            {
                TransactionId = 1,
                TransactionDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-10)),
                Type = Transaction.TransactionType.Expense,
                IsRecurring = true,
                Note = "Weekly groceries",
                TransactionAmount = 85.50,
                Category = groceries,
                User = user
            },
            new Transaction
            {
                TransactionId = 2,
                TransactionDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)),
                Type = Transaction.TransactionType.Expense,
                IsRecurring = false,
                Note = "Monthly utility bill",
                TransactionAmount = 120.75,
                Category = utilities,
                User = user
            },
            new Transaction
            {
                TransactionId = 3,
                TransactionDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-15)),
                Type = Transaction.TransactionType.Income,
                IsRecurring = true,
                Note = "Monthly salary",
                TransactionAmount = 3000.00,
                Category = salary,
                User = user
            },
            new Transaction
            {
                TransactionId = 4,
                TransactionDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)),
                Type = Transaction.TransactionType.Expense,
                IsRecurring = false,
                Note = "Cinema tickets",
                TransactionAmount = 45.00,
                Category = entertainment,
                User = user
            }
        };

            user.TransactionList.AddRange(transactions);

            return user;
        }
    }
}
