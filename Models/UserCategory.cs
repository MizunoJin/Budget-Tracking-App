namespace Budget_Tracking_App.Models
{
    public class UserCategory : Category
    {
        public required User User { get; set; }
    }
}
