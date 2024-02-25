namespace Budget_Tracking_App.Models
{
    abstract public class Category
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public Budget? Budget { get; set; }
        public List<Transaction> TransactionList { get; set; } = new List<Transaction>();
        public double Balance { get; set; }
    }
}
