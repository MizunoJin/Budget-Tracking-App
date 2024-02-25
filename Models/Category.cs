namespace Budget_Tracking_App.Models
{
    abstract public class Category
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public DateOnly OpeningDate { get; set; }
        public Budget? BudgetAllocated { get; set; }
        public required List<Transaction> TransactionList { get; set; }
        public double Balance { get; set; }
    }
}
