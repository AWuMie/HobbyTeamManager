namespace MySqlTestRazor.Models;

public enum ConfirmationMode
{
    SignedIn,
    SignedOut,
}

public class Site
{
    public int Id { get; set; }

    public string? Name { get; set; } = string.Empty;
    
    public byte[]? Logo { get; set; } = null;
    
    public string? Description { get; set; } = string.Empty;

    public string? Rules { get; set; } = string.Empty;
    
    public ConfirmationMode ConfirmationMode { get; set; }

    public string TeamColor1 { get; set; } = string.Empty;
    public string TeamColor2 { get; set; } = string.Empty;

    //public IList<Player>? Players { get; set; }

    //public IList<Season>? Seasons { get; set; }
}
