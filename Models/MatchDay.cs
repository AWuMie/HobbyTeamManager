namespace MySqlTestRazor.Models;

public class MatchDay
{
    public MatchDay()
    {
    }

    public MatchDay(DateTime dateTime, int seasonId)
    {
        Date = dateTime;
        SeasonId = seasonId;
    }

    public int Id { get; set; }

    public DateTime Date { get; set; }

    // one to many relationship between Player and MatchDay to cover the beer-responsible
    public int? BeerResponsibleId { get; set; }
    public Player? BeerResponsible { get; set; }

    // twice a one to one relationship between Team and MatchDay to cover the two teams
    // that are playing on a matchday -> Team White and Team Red
    public Team? TeamWhite { get; set; } = null;

    public Team? TeamRed { get; set; } = null;

    // one to many relationship between MatchDay and Season.
    // A MatchDay is linked to one Season while
    // a Season has many MatchDays
    public int? SeasonId { get; set; }
    public Season? Season { get; set; }
}
