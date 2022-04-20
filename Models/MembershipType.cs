namespace HobbyTeamManager.Models;

public class MembershipType
{
    public static readonly string Member = "Mitglied";
    public static readonly string Guest = "Gast";
    public static readonly string Ex = "Ehemaliger";

    public int Id { get; set; }
    public string Name { get; set; } = "";

    // one to many relationship between Player and MembershipType
    public ICollection<Player>? Players { get; set; }
}
