namespace MySqlTestRazor.Models;

public class TeamColor
{
    public static readonly string Weiss = "Weiss";
    public static readonly string Rot = "Rot";

    public int Id { get; set; }
    public string? Name { get; set; }

    // one to many relationship between Team and TeamColor
    public ICollection<Team>? Teams { get; set; }
}
