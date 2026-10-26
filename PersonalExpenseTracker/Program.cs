
Console.WriteLine("================================");
Console.WriteLine("     PERSONAL EXPENSE TRACKER");
Console.WriteLine("================================");

Console.WriteLine("1. Add Expense");
Console.WriteLine("2. View Expenses");
Console.WriteLine("3. View Total Expenses");
Console.WriteLine("4. Exit");

Console.Write("Choose an option: ");

string? choice = Console.ReadLine();

Console.WriteLine($"You selected option: {choice}");
