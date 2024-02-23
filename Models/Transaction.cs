namespace Budget_Tracking_App.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateOnly TransactionDate { get; set; }
        public TransactionType Type { get; set; }
        public bool IsRecurring { get; set; }
        public required string Note { get; set; }
        public double TransactionAmount { get; set; }
        public required Category Category { get; set; }
        public required User User { get; set; }

        public enum TransactionType
        {
            Income,
            Expense
        }
    }
}
