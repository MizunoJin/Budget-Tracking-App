using Budget_Tracking_App.Models;

namespace Budget_Tracking_App.Seeds
{
    public class SeedData
    {
        public static User GetTestUser()
        {
            // Initialize categories
            var groceries = CategoryFactory.CreatePresetCategory("Groceries");
            var utilities = CategoryFactory.CreatePresetCategory("Utilities");
            var salary = CategoryFactory.CreatePresetCategory("Salary");
            var entertainment = CategoryFactory.CreatePresetCategory("Entertainment");

            // Initialize user with transactions
            var user = new User
            {
                UserId = 1,
                Name = "John Doe",
                Email = "john.doe@example.com"
            };

            // Create UserCategories for user
            UserCategory UserCategory = CategoryFactory.CreateUserCategory("Dating", user);
            user.UserCategoryList.Add(UserCategory);

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

            Budget budget1 = new Budget { Amount = 5000.0, Category = UserCategory, User = user };
            user.Budgets.Add(budget1);
            Budget budget2 = new Budget { Amount = 500.0, Category = groceries, User = user };
            user.Budgets.Add(budget2);
            Budget budget3 = new Budget { Amount = 300.0, Category = entertainment, User = user };
            user.Budgets.Add(budget3);

            return user;
        }
    }
}
