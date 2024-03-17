namespace Budget_Tracking_App.Models
{
    public class CategoryFactory
    {
        private static int nextCategoryId = 1;

        public static PresetCategory CreatePresetCategory(string name)
        {
            var category = new PresetCategory
            {
                CategoryId = nextCategoryId++,
                Name = name,
            };

            return category;
        }

        public static UserCategory CreateUserCategory(string name, User user)
        {
            var category = new UserCategory
            {
                CategoryId = nextCategoryId++,
                Name = name,
                User = user
            };

            return category;
        }
    }
}
