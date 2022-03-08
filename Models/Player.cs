using Microsoft.AspNetCore.Identity;

namespace MySqlTestRazor.Models;

public class Player
{
    public Player()
    {
        //TeamPlayers = new HashSet<TeamPlayer>();
    }

    public int Id { get; set; }

    [PersonalData]
    public string FirstName { get; set; } = "";

    [PersonalData]
    public string LastName { get; set; } = "";

    [PersonalData]
    public string NickName { get; set; } = "";

    [PersonalData]
    public DateTime BirthDate { get; set; } = DateTime.Now;

    [PersonalData]
    public byte[]? ProfilePicture { get; set; }

    public bool IsAdmin { get; set; } = false;

    // calculated value - TBD
    // basis of the automated team-builder
    // in the future could be a class/model/table with several aspects of abilities of a player
    public float Score { get; set; } = 0.0F;

    // only valid for guest-players which don't have an
    // automatically calculated score
    // one to many relationship to itself!
    public int ScoreFromPlayerId { get; set; }
    public Player? ScoreFromPlayer { get; set; }
    public virtual ICollection<Player>? ScoreForPlayers { get; set; }

    // one to many relationship between Player and MembershipType
    // a Player has one MembershipType
    // a MembershipType is valid for many Players
    public int MembershipTypeId { get; set; }
    public MembershipType? MembershipType { get; set; }

    // many to many releationship between teams and players:
    // a team has many players
    // and
    // a player can play in many teams (a team is valid for one matchday)
    //public ICollection<TeamPlayer>? TeamPlayers { get; set; }

    // one to one relationship with MatchDay to cover the beer-responsible
    //public int MatchDayId { get; set; } = 0;
    //public MatchDay? BeerResponsibleOfMatchDay { get; set; }
}
