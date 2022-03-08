namespace MySqlTestRazor.Models;

public class MatchDay
{
    public int Id { get; set; }

    public DateTime DateTime { get; set; }

    // one to one relationship between Player and MatchDay to cover the beer-responsible
    public Player? BeerResponsible { get; set; }

    //public Team? TeamWhite { get; set; } = null;

    //public Team? TeamRed { get; set; } = null;
}
