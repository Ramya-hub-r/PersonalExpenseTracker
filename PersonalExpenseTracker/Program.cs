
using System;
using System.Collections.Generic;

class Expense
{
    public string Category { get; set; } = "";
    public decimal Amount { get; set; }
    public string Description { get; set; } = "";
    public DateTime Date { get; set; }
}

class Program
{
    static List<Expense> expenses = new List<Expense>();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n================================");
            Console.WriteLine("     YOUR PERSONAL EXPENSE TRACKER");
            Console.WriteLine("================================");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View Expenses");
            Console.WriteLine("3. View Total Expenses");
            Console.WriteLine("4. Search Expenses by Category");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddExpense();
                    break;

                case "2":
                    ViewExpenses();
                    break;

                case "3":
                    ViewTotalExpenses();
                    break;

                case "4":
                    SearchExpensesByCategory();
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Thank you for using Expense Tracker!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddExpense()
    {
        Console.Write("Enter category (Food, Travel, Shopping, etc.): ");
        string category = Console.ReadLine() ?? "";

        Console.Write("Enter amount: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
        {
            Console.WriteLine("Please enter a valid amount greater than zero.");
            return;
        }

        Console.Write("Enter description: ");
        string description = Console.ReadLine() ?? "";

        Expense expense = new Expense
        {
            Category = category,
            Amount = amount,
            Description = description,
            Date = DateTime.Today
        };

        expenses.Add(expense);

        Console.WriteLine("Expense added successfully!");
    }

    static void ViewExpenses()
    {
        if (expenses.Count == 0)
        {
            Console.WriteLine("No expenses recorded yet.");
            return;
        }

        Console.WriteLine("\n--- Expense List ---");

        foreach (Expense expense in expenses)
        {
            Console.WriteLine(
                $"Date: {expense.Date:yyyy-MM-dd} | " +
                $"Category: {expense.Category} | " +
                $"Amount: {expense.Amount:F2} | " +
                $"Description: {expense.Description}");
        }
    }

    static void ViewTotalExpenses()
    {
        decimal total = 0;

        foreach (Expense expense in expenses)
        {
            total += expense.Amount;
        }

        Console.WriteLine($"Total expenses: {total:F2}");
    }

    static void SearchExpensesByCategory()
    {
        Console.Write("Enter category to search: ");
        string category = Console.ReadLine() ?? "";

        bool found = false;

        foreach (Expense expense in expenses)
        {
            if (expense.Category.Equals(
                category, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(
                    $"Date: {expense.Date:yyyy-MM-dd} | " +
                    $"Category: {expense.Category} | " +
                    $"Amount: {expense.Amount:F2} | " +
                    $"Description: {expense.Description}");

                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No expenses found for this category.");
        }
    }

}
