namespace MySqlTestRazor.Models;

public enum TeamColor
{
    White = 1,
    Red = 2,
}

public class Team
{
    public Team()
    {
        TeamPlayers = new HashSet<TeamPlayer>();
    }

    public int Id { get; set; }

    public TeamColor TeamColor { get; set; } = TeamColor.White;

    public ICollection<TeamPlayer> TeamPlayers { get; set; }

    public int Goals { get; set; } = 0;

    // one to one relationship between MatchDay and Team
    // a MatchDay has one White (and one Red) Team
    // a Team is valid for exactly one MatchDay
    public int MatchDayIdForTeamWhite { get; set; }
    public MatchDay? MatchDayForTeamWhite { get; set; }
    public int MatchDayIdForTeamRed { get; set; }
    public MatchDay? MatchDayForTeamRed { get; set; }
}
