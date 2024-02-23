using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracking_App.Models
{
    public class Budget
    {
        public int BudgetId { get; set; }
        public double amount { get; set; }
        public double CategoryId { get; set; }
        public DateOnly Category_Budget { get; set; }
        public double Ramaining_budget { get; set; }
    }
}
