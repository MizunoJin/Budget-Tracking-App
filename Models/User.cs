namespace Budget_Tracking_App.Models
{
    public class User
    {
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required List<Transaction> TransactionList { get; set; }
    }
}
