using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MySqlTestRazor.Models;

public class Site
{
    public int Id { get; set; }

    public string? Name { get; set; } = string.Empty;
    
    public byte[]? Logo { get; set; } = null;

    [Display(Name = "Motto")]
    public string? Description { get; set; } = string.Empty;

    [Display(Name = "Regeln")]
    public string? Rules { get; set; } = string.Empty;
    
    [Display(Name = "Art der Teilnahmebestätigung")]
    public int ConfirmationModeId { get; set; }

    [Display(Name = "Mannschaftsfarbe 1")]
    public string TeamColor1 { get; set; } = string.Empty;
    [Display(Name = "Mannschaftsfarbe 2")]
    public string TeamColor2 { get; set; } = string.Empty;

    //public IList<Player>? Players { get; set; }

    //public IList<Season>? Seasons { get; set; }

    static public Dictionary<int, string> confirmationMode = new()
    {
        {1, "Automatisch AB-gemeldet - aktive AN-meldung" },
        {2, "Automatisch AN-gemeldet - aktive AB-meldung" },
    };
}
