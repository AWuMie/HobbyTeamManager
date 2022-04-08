using System.ComponentModel.DataAnnotations;

namespace MySqlTestRazor.Models;

public class Player
{
    public Player()
    {
        TeamPlayers = new HashSet<TeamPlayer>();
        BeerResponsibleOnMatchDays = new HashSet<MatchDay>();
        ScoreForPlayers = new HashSet<Player>();
    }

    public int Id { get; set; }

    [Display(Name = "Emailadresse")]
    public string Emailaddress { get; set; } = string.Empty;

    public bool EmailAdressConfirmed { get; set; } = false;

    // one-to-one relationship Password <-> Player
    public Password? Password { get; set; }

    [Display(Name = "Vorname")]
    public string FirstName { get; set; } = "";

    [Display(Name = "Nachname")]
    public string LastName { get; set; } = "";

    [Display(Name = "Spitzname / Motto")]
    public string NickName { get; set; } = "";

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

    // only valid for guest-players which don't have an
    // automatically calculated score
    // one to many relationship to itself!
    [Display(Name = "Stärke von Spieler")]
    public int? ScoreFromPlayerId { get; set; }
    public Player? ScoreFromPlayer { get; set; }
    public ICollection<Player>? ScoreForPlayers { get; set; }

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

    // one to many relationship between Player and MatchDay to cover the beer-responsible
    // a player can be beer responsible on many matchdays
    // there is only one beer responsible per matchday
    public ICollection<MatchDay>? BeerResponsibleOnMatchDays { get; set; }
}
