namespace Budget_Tracking_App.Models
{
    public class Budget
    {
        public int BudgetId { get; set; }
        public double Amount { get; set; }
        public required Category Category { get; set; }
        public required User User { get; set; }

        public double CalcSpent()
        {
            return User.CalcSpent(Category);
        }
    }
}
