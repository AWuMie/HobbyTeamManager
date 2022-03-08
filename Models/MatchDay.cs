namespace MySqlTestRazor.Models;

public class MatchDay
{
    public int Id { get; set; }

    public DateTime DateTime { get; set; }

    // one to one relationship between Player and MatchDay to cover the beer-responsible
    public Player? BeerResponsible { get; set; }

    // twice a one to one relationship between Team and MatchDay to cover the two teams
    // that are playing on a matchday -> Team White and Team Red
    public Team? TeamWhite { get; set; } = null;

    public Team? TeamRed { get; set; } = null;
}
