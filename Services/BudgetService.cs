using Budget_Tracking_App.Models;

namespace Budget_Tracking_App.Services
{
    public class BudgetService
    {
        public static void EnterBudget(User user)
        {
            List<Category> categories = user.GetCategories();

            CategoryService.DisplayCategories(categories);

            var category = CategoryService.SelectCategory(categories);

            Console.WriteLine("Enter the budget amount:");
            double amount = Convert.ToDouble(Console.ReadLine());

            Budget newBudget = new Budget
            {
                User = user,
                Category = category,
                Amount = amount
            };

            user.Budgets.Add(newBudget);

            Console.WriteLine($"Budget of {amount} added to category {category.Name}.");
        }

        public static void TrackBudget(User user)
        {
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
            }

            Console.WriteLine("Total Budget: " + totalBudget.ToString("C"));
            Console.WriteLine("Total Spent: " + totalSpent.ToString("C"));
            Console.WriteLine("Total Remaining: " + (totalBudget - totalSpent).ToString("C"));
        }
    }
}
