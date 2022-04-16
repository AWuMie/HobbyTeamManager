using System.ComponentModel.DataAnnotations;

namespace MySqlTestRazor.Models;

public class Site
{
    public int Id { get; set; }

    public string Name { get; set; } = "";
    
    public byte[]? Logo { get; set; } = null;

    [Display(Name = "Motto")]
    public string? Description { get; set; } = string.Empty;

    // should be name and motto?
    //public string Headline { get; set; } = "Hobby Team Manager";
    //public string Headline2 { get; set; } = "";

    [Display(Name = "Regeln")]
    public string? Rules { get; set; } = string.Empty;
    
    [Display(Name = "Teilnahmebestätigungsmodell")]
    public int ConfirmationModeId { get; set; }

    [Display(Name = "Mannschaftsfarbe 1")]
    public string TeamColor1 { get; set; } = "#ffffff";
    [Display(Name = "Mannschaftsfarbe 2")]
    public string TeamColor2 { get; set; } = "#ff0000";

    // should be name and motto?
    //public string Headline { get; set; } = "Hobby Team Manager";
    //public string Headline2 { get; set; } = "";

    // Look and Feel
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

    //public IList<Player>? Players { get; set; }

    //public IList<Season>? Seasons { get; set; }

    public static readonly Dictionary<int, string> confirmationMode = new()
    {
        {1, "Automatisch AB-gemeldet - aktive AN-meldung" },
        {2, "Automatisch AN-gemeldet - aktive AB-meldung" },
    };
}
