using System.ComponentModel.DataAnnotations;

namespace HobbyTeamManager.Models;

public class Site
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public byte[]? Logo { get; set; } = null;

    [Display(Name = "Motto / Information")]
    public string? Motto { get; set; }

    // should be name and motto?
    [Display(Name = "Überschrift / Beschreibung")]
    public string Headline { get; set; } = string.Empty;

    [Display(Name = "optionale Überschrift 2")]
    public string? Headline2 { get; set; }

    [Display(Name = "Regeln")]
    public string? Rules { get; set; } = string.Empty;
    
    [Display(Name = "Teilnahmebestätigung")]
    public int ConfirmationModeId { get; set; }

    [Display(Name = "Farbe Mannschaft 1")]
    public string TeamColor1 { get; set; } = "#ffffff";
    [Display(Name = "Farbe Mannschaft 2")]
    public string TeamColor2 { get; set; } = "#ff0000";

    // Look and Feel
    // Menu position
    [Display(Name = "Menüposition")]
    public int MenuPositionId { get; set; }

    // colors of pages
    [Display(Name = "Hintergrundfarbe HTML-Body")]
    public string BgColorBody { get; set; } = "#000000";    // black

    [Display(Name = "Textfarbe HTML-Body")]
    public string FgColorBody { get; set; } = "#ffa500";    // orange

    [Display(Name = "Hintergrundfarbe HTML-Header")]
    public string BgColorHeader { get; set; } = "#000000";

    [Display(Name = "Textfarbe HTML-Header")]
    public string FgColorHeader { get; set; } = "#ffa500";

    [Display(Name = "Hintergrundfarbe Main")]
    public string BgColorMain { get; set; } = "#000000";

    [Display(Name = "Textfarbe Main")]
    public string FgColorMain { get; set; } = "#ffa500";

    [Display(Name = "Hintergrundfarbe HTML-Footer")]
    public string BgColorFooter { get; set; } = "#000000";

    [Display(Name = "Textfarbe HTML-Footer")]
    public string FgColorFooter { get; set; } = "#ffa500";

    [Display(Name = "Aktuelle Spielsaison")]
    public int SeasonId { get; set; }

    ///////////////////
    // Relationships //
    ///////////////////

    // one to many relationship between Site and Season
    // a Season is linked to one Site while
    // a Site has many Seasons
    public IList<Season>? Seasons { get; set; }

    // many to many releationship between teams and players:
    // a team has many players and
    // a player can play in many teams (a team is valid for one matchday)
    public ICollection<SitePlayer>? SitePlayers { get; set; }

    public string GetConfirmationMode(int index)
    {
        return confirmationMode[index];
    }

    public static readonly Dictionary<int, string> confirmationMode = new()
    {
        {1, "Automatisch AB-gemeldet - aktive AN-meldung" },
        {2, "Automatisch AN-gemeldet - aktive AB-meldung" },
    };

    public string GetMenuPosition(int index)
    {
        return menuPosition[index];
    }

    public static string menuPositionTop = "Menüposition OBEN";
    public static string menuPositionLeft = "Menüposition LINKS (experimentell)";
    public static readonly Dictionary<int, string> menuPosition = new()
    {
        { 1, menuPositionTop },
        { 2, menuPositionLeft }
    };
}
