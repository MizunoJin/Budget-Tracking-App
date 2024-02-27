namespace Budget_Tracking_App;

class Program
{
    static void Main(string[] args)
    {
        var app = BudgetApp.GetInstance();
        app.Run();
    }
}


