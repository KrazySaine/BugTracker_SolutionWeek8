using BugTracker.Core;

var service = new BugService();
bool exit = false;

while (!exit)
{
    Console.WriteLine("\nBug Tracker");
    Console.WriteLine("1. Add Bug");
    Console.WriteLine("2. View Bugs");
    Console.WriteLine("3. Update Bug Status");
    Console.WriteLine("4. Exit");
    Console.Write("Choose an option: ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.Write("Enter title: ");
            var title = Console.ReadLine();
            Console.Write("Enter description: ");
            var desc = Console.ReadLine();
            var bug = new Bug(title, desc);
            service.AddBug(bug);
            Console.WriteLine("Bug added!");
            break;

        case "2":
            var all = service.GetAllBugs();
            foreach (var b in all)
            {
                Console.WriteLine($"ID: {b.Id}, Title: {b.Title}, Status: {b.Status}");
            }
            break;

        case "3":
            Console.Write("Enter Bug ID: ");
            if (int.TryParse(Console.ReadLine(), out int bugId))
            {
                Console.Write("Enter new status (Open, InProgress, Pending, Closed): ");
                var newStatusText = Console.ReadLine();
                if (Enum.TryParse(newStatusText, out BugStatus newStatus))
                {
                    bool success = service.UpdateStatus(bugId, newStatus);
                    Console.WriteLine(success ? "Updated!" : "Bug not found.");
                }
                else
                {
                    Console.WriteLine("Invalid status.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            break;

        case "4":
            exit = true;
            break;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}