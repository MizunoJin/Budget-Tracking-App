
using Budget_Tracking_App.Models;

namespace Budget_Tracking_App.Services
{
    public class CategoryService
    {
        private static readonly Logger logger = Logger.GetInstance();

        public static void DisplayCategories(List<Category> categories)
        {
            logger.Debug("Displaying categories.");

            Console.WriteLine("Please select a category by entering the corresponding number:");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i].Name}");
            }

            logger.Info("Categories displayed.");
        }

        public static Category SelectCategory(List<Category> categories)
        {
            logger.Debug("Selecting a category.");

            int categoryIndex = 0;
            while (categoryIndex < 1 || categoryIndex > categories.Count)
            {
                Console.Write("Enter the number of the category: ");
                categoryIndex = Convert.ToInt32(Console.ReadLine());
            }

            logger.Info($"Category selected: {categories[categoryIndex - 1].Name}");
            return categories[categoryIndex - 1];
        }

        public static void ViewCategories(User user)
        {
            logger.Debug($"Viewing categories for user {user.Name}.");

            List<Category> categories = user.GetCategories();

            foreach (var category in categories)
            {
                var budget = user.Budgets.FirstOrDefault(b => b.Category == category);
                Console.WriteLine($"Category ID: {category.CategoryId}");
                Console.WriteLine($"Name: {category.Name}");
                Console.WriteLine($"Budget Allocated: {budget?.Amount.ToString() ?? "N/A"}");
                Console.WriteLine("------------------------------");
            }

            logger.Info($"Categories viewed for user {user.Name}.");
        }

        public static void EnterCategory(User user)
        {
            logger.Debug($"Entering a new category for user {user.Name}.");

            bool isUniqueCategoryName = false;
            string categoryName = "";

            while (!isUniqueCategoryName)
            {
                Console.WriteLine("Enter new category name:");
                categoryName = Console.ReadLine() ?? "Default Category";

                // Check if the category name already exists
                if (user.GetCategories().Any(cat => cat.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine($"A category with the name '{categoryName}' already exists. Please enter a different name.");
                }
                else
                {
                    isUniqueCategoryName = true;
                }
            }

            UserCategory newUserCategory = CategoryFactory.CreateUserCategory(categoryName, user);
            user.UserCategoryList.Add(newUserCategory);

            Console.WriteLine($"New category '{categoryName}' has been added successfully.");
            logger.Info($"New category '{categoryName}' added for user {user.Name}.");
        }
    }
}
