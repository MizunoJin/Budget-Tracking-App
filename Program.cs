using Budget_Tracking_App.Models;
using Budget_Tracking_App.Seeds;

namespace Budget_Tracking_App;

class Program
{
    static void Main(string[] args)
    {
        User user = SeedData.GetTestUser();
        var app = new BudgetApp(user);
        app.Run();
    }
}


