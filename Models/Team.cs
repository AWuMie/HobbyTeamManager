namespace MySqlTestRazor.Models;

public enum TeamColor
{
    White = 1,
    Red = 2,
}

public class Team
{
    public int Id { get; set; }

    public TeamColor TeamColor { get; set; } = TeamColor.White;

    public Player? GoalKeeper { get; set; }

    public IList<Player>? Players { get; set; }

    public int Goals { get; set; } = 0;
}
