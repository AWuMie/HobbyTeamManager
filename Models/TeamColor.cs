namespace MySqlTestRazor.Models;

public class TeamColor
{
    public TeamColor()
    {
        Teams = new List<Team>();
    }

    public int TeamColorId { get; set; }
    public string? Name { get; set; } = "";

    // one to many relationship between Team and TeamColor
    public ICollection<Team>? Teams { get; set; }
}
