
using Budget_Tracking_App.Models;

namespace Budget_Tracking_App.Services
{
    public class CategoryService
    {
        public static void DisplayCategories(List<Category> categories)
        {
            // Display categories
            Console.WriteLine("Please select a category by entering the corresponding number:");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i].Name}");
            }
        }

        public static Category SelectCategory(List<Category> categories)
        {
            // Select category
            int categoryIndex = 0;
            while (categoryIndex < 1 || categoryIndex > categories.Count)
            {
                Console.Write("Enter the number of the category: ");
                categoryIndex = Convert.ToInt32(Console.ReadLine());
            }
            return categories[categoryIndex - 1];
        }

        public static void ViewCategories(User user)
        {
            List<Category> categories = user.GetCategories();

            foreach (var category in categories)
            {
                var budget = user.Budgets.FirstOrDefault(b => b.Category == category);
                Console.WriteLine($"Category ID: {category.CategoryId}");
                Console.WriteLine($"Name: {category.Name}");
                Console.WriteLine($"Budget Allocated: {budget?.Amount.ToString() ?? "N/A"}");
                Console.WriteLine($"Balance: {category.Balance}");
                Console.WriteLine("------------------------------");
            }
        }

        public static void EnterCategory(User user)
        {
            Console.WriteLine("Enter new category name:");
            string categoryName = Console.ReadLine() ?? "Default Category";

            UserCategory newUserCategory = new UserCategory
            {
                User = user,
                Name = categoryName,
                Balance = 0 // Initial balance can be set here
            };

            user.UserCategoryList.Add(newUserCategory);

            Console.WriteLine($"New category '{categoryName}' has been added successfully.");
        }
    }
}
