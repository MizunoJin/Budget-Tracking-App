namespace Budget_Tracking_App.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateOnly OpeningDate { get; set; }
        public Budget BudgetAllocated { get; set; }
        public List<Transaction> TransactionList { get; set; }
        public double Balance { get; set; }
    }
}
