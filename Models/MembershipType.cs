namespace MySqlTestRazor.Models;

public class MembershipType
{
    public int Id { get; set; }
    public string? Name { get; set; }

    // one to many relationship between Player and MembershipType
    // public ICollection<Player>? Players { get; set; }
}
