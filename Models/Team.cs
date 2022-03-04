using System.ComponentModel.DataAnnotations;

namespace MySqlTestRazor.Models;

public enum TeamColor
{
    White = 1,
    Red = 2,
}

public class Team
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Mannschaftsfarbe")]
    public TeamColor TeamColor { get; set; } = TeamColor.White;

    //[Display(Name = "Torwart")]
    //public Player? GoalKeeper { get; set; }

    [Required]
    [Display(Name = "Spielerliste")]
    public IList<TeamPlayer>? TeamPlayers { get; set; }

    [Display(Name = "geschossene Tore")]
    public int Goals { get; set; } = 0;
}
