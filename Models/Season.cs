using System.ComponentModel.DataAnnotations;

namespace HobbyTeamManager.Models;

public class Season
{
    public int Id { get; set; }

    [Display(Name = "Jahr")]
    public int Year { get; set; }

    [Display(Name = "Startmonat")]
    public int StartMonth { get; set; }

    [Display(Name = "Wochentag")]
    public int MatchOnDay { get; set; }

    // one to many relationship between MatchDay and Season.
    // A MatchDay is linked to one Season while
    // a Season has many MatchDays
    [Display(Name = "Spieltage")]
    public IList<MatchDay>? MatchDays { get; set; }
}
