using Budget_Tracking_App.Models;

namespace Budget_Tracking_App.Services
{
    public class BudgetService
    {
        private static readonly Logger logger = Logger.GetInstance();

        public static void EnterBudget(User user)
        {
            logger.Debug($"EnterBudget started for user {user.Name}.");

            List<Category> categories = user.GetCategories();
            CategoryService.DisplayCategories(categories);
            var category = CategoryService.SelectCategory(categories);

            double amount = 0;
            bool isValidAmount = false;

            while (!isValidAmount)
            {
                Console.WriteLine("Enter the budget amount (positive number):");
                if (double.TryParse(Console.ReadLine(), out amount) && amount >= 0)
                {
                    isValidAmount = true;
                }
                else
                {
                    Console.WriteLine("Invalid amount. Please enter a positive number.");
                }
            }

            Budget newBudget = new Budget
            {
                User = user,
                Category = category,
                Amount = amount
            };

            user.Budgets.Add(newBudget);

            Console.WriteLine($"Budget of {amount} added to category {category.Name}.");
            logger.Info($"Budget of {amount:C} added to category {category.Name} for user {user.Name}.");

            logger.Debug("EnterBudget completed.");
        }

        public static void TrackBudget(User user)
        {
            logger.Debug($"TrackBudget started for user {user.Name}.");

            double totalSpent = 0;
            double totalBudget = user.CalcTotalBudget();

            Console.WriteLine("Budget Tracking Report:");
            Console.WriteLine("-----------------------");

            foreach (var budget in user.Budgets)
            {
                double spent = budget.CalcSpent();
                totalSpent += spent;
                double remaining = budget.Amount - spent;

                Console.WriteLine($"Category: {budget.Category.Name}");
                Console.WriteLine($"Budgeted: {budget.Amount:C}");
                Console.WriteLine($"Spent: {spent:C}");
                Console.WriteLine($"Remaining: {remaining:C}");
                Console.WriteLine("-------------");

                logger.Info($"Budget tracking for {budget.Category.Name}: Budgeted: {budget.Amount:C}, Spent: {spent:C}, Remaining: {remaining:C}");
            }

            Console.WriteLine("Total Budget: " + totalBudget.ToString("C"));
            Console.WriteLine("Total Spent: " + totalSpent.ToString("C"));
            Console.WriteLine("Total Remaining: " + (totalBudget - totalSpent).ToString("C"));

            logger.Info($"Total Budget: {totalBudget:C}, Total Spent: {totalSpent:C}, Total Remaining: {(totalBudget - totalSpent):C} for user {user.Name}.");
            logger.Debug("TrackBudget completed.");
        }
    }
}
