using System.ComponentModel.DataAnnotations;

namespace HobbyTeamManager.Models;

public class Player
{
    public static readonly string AdminRole = "Admin";
    public static readonly string UserRole = "User";

    public Player()
    {
        TeamPlayers = new HashSet<TeamPlayer>();
        BeerResponsibleOnMatchDays = new HashSet<MatchDay>();
    }

    public int Id { get; set; }

    [Display(Name = "Emailadresse")]
    public string Emailaddress { get; set; } = string.Empty;

    public bool EmailAdressConfirmed { get; set; } = false;

    public int PasswordSalt { get; set; }

    public byte[]? PasswordHash { get; set; }

    public DateTime RowVersion { get; set; }

    [Display(Name = "Vorname")]
    public string FirstName { get; set; } = "";

    [Display(Name = "Nachname")]
    public string? LastName { get; set; } = "";

    [Display(Name = "Spitzname / Motto")]
    public string? NickName { get; set; } = "";

    [Display(Name = "Geburtstag")]
    public DateTime BirthDate { get; set; } = DateTime.Now;

    [Display(Name = "Profilbild")]
    public byte[]? ProfilePicture { get; set; }

    [Display(Name = "Administrator")]
    public bool IsAdmin { get; set; } = false;

    // basis of the automated team-builder
    // See TrueSkill / TrueSkill 2!!!
    [Display(Name = "Spielerstärke")]
    public float Score { get; set; } = 0.0F;

    ///////////////////
    // Relationships //
    ///////////////////

    // one to many relationship between Player and MembershipType
    // a Player has one MembershipType
    // a MembershipType is valid for many Players
    [Display(Name = "Spielerstatus")]
    public int MembershipTypeId { get; set; }
    public MembershipType? MembershipType { get; set; }

    // many to many releationship between teams and players:
    // a team has many players and
    // a player can play in many teams (a team is valid for one matchday)
    public ICollection<TeamPlayer>? TeamPlayers { get; set; }

    // many to many releationship between sites and players:
    // a site has many players and
    // a player can be member in multiple sites (site = hobby team)
    public ICollection<SitePlayer>? SitePlayers { get; set; }

    // one to many relationship between Player and MatchDay to cover the beer-responsible
    // a player can be beer responsible on many matchdays
    // there is only one beer responsible per matchday
    public ICollection<MatchDay>? BeerResponsibleOnMatchDays { get; set; }
}
