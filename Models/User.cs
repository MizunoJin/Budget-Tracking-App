namespace Budget_Tracking_App.Models
{
    public class User
    {
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public List<Transaction> TransactionList { get; set; } = new List<Transaction>();
        public List<UserCategory> UserCategoryList { get; set; } = new List<UserCategory>();
        public List<Budget> Budgets { get; set; } = new List<Budget>();
    }
}
