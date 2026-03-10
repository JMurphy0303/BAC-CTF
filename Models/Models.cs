namespace CtfApp.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string FullName { get; set; } = "";
}

public class Document
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public int OwnerId { get; set; }
}

public static class DataStore
{
    public static List<User> Users { get; } = new()
    {
        new User { Id = 1, Username = "employee",   Password = "password123",   FullName = "John Doe" },
        new User { Id = 2, Username = "msmith", Password = "spring2024", FullName = "Mary Smith" },
        new User { Id = 3, Username = "rlee",   Password = "football1",  FullName = "Robert Lee" },
    };

    public static List<Document> Documents { get; } = new()
    {
        new Document { Id = 1, Title = "Q1 Expense Report",     Content = "Total expenses: $14,200. Travel: $3,400. Supplies: $800.",                        OwnerId = 1 },
        new Document { Id = 2, Title = "Project Alpha Notes",   Content = "Meeting notes from March 3rd. Action items assigned to team leads.",              OwnerId = 1 },
        new Document { Id = 3, Title = "Annual Performance Review",    Content = "Review for Mary Smith. Rating: Exceeds Expectations. Bonus approved.",    OwnerId = 2 },
        new Document { Id = 4, Title = "Team Roster Q2",        Content = "Engineering team contacts and reporting structure for Q2 planning.",             OwnerId = 2 },
        new Document { Id = 5, Title = "Vendor Contract Draft", Content = "Draft agreement with SupplyCo Ltd. Awaiting legal sign-off.",                    OwnerId = 3 },

        // FLAG DOCUMENT — OwnerId = 99 (no user has this ID, so it never appears on any dashboard)
        // Students must enumerate document IDs to discover it
        new Document { Id = 6, Title = "CONFIDENTIAL", Content = "🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩🚩", OwnerId = 99 },
    };
}
