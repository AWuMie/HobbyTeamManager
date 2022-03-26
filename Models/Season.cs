namespace MySqlTestRazor.Models;

public class Season
{
    public int Id { get; set; }

    public int Year { get; set; }

    public int StartMonth { get; set; }

    public int MatchOnDay { get; set; }

    // one to many relationship between MatchDay and Season.
    // A MatchDay is linked to one Season while
    // a Season has many MatchDays
    public IList<MatchDay>? MatchDays { get; set; }
}
