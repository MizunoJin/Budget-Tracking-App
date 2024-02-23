using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Budget_Tracking_App.Models;

namespace Budget_Tracking_App.Seeds
{
    public class SeedData
    {
        public static User GetTestUser()
        {
            // Initialize categories
            var groceries = new Category { Name = "Groceries" };
            var utilities = new Category { Name = "Utilities" };
            var salary = new Category { Name = "Salary" };
            var entertainment = new Category { Name = "Entertainment" };

                        // Initialize user with transactions
            var user = new User
            {
                UserId = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                TransactionList = new List<Transaction>()
            };

            // Initialize transactions
            var transactions = new List<Transaction>
        {
            new Transaction
            {
                TransactionId = 1,
                TransactionDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-10)),
                Type = Transaction.TransactionType.Expense,
                IsRecurring = true,
                Note = "Weekly groceries",
                TransactionAmount = 85.50,
                Category = groceries,
                User = user
            },
            new Transaction
            {
                TransactionId = 2,
                TransactionDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)),
                Type = Transaction.TransactionType.Expense,
                IsRecurring = false,
                Note = "Monthly utility bill",
                TransactionAmount = 120.75,
                Category = utilities,
                User = user
            },
            new Transaction
            {
                TransactionId = 3,
                TransactionDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-15)),
                Type = Transaction.TransactionType.Income,
                IsRecurring = true,
                Note = "Monthly salary",
                TransactionAmount = 3000.00,
                Category = salary,
                User = user
            },
            new Transaction
            {
                TransactionId = 4,
                TransactionDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)),
                Type = Transaction.TransactionType.Expense,
                IsRecurring = false,
                Note = "Cinema tickets",
                TransactionAmount = 45.00,
                Category = entertainment,
                User = user
            }
        };

            user.TransactionList.AddRange(transactions);

            return user;
        }
    }
}
