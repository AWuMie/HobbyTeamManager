namespace MySqlTestRazor.Models;

public class Team
{
    public Team()
    {
        TeamPlayers = new HashSet<TeamPlayer>();
    }

    public int Id { get; set; }

    public int TeamColorId { get; set; }
    public TeamColor? TeamColor { get; set; }

    // many to many releationship between teams and players:
    // a team has many players and
    // a player can play in many teams (a team is valid for one matchday)
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
