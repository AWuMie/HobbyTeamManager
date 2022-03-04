using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MySqlTestRazor.Models;

public enum MembershipType
{
    Member = 1,
    Guest = 2,
    Ex = 3
}

public class Player
{
    public int Id { get; set; }

    [PersonalData]
    [Required]
    [StringLength(50)]
    [Display(Name = "Vorname")]
    public string? FirstName { get; set; } = "";

    [PersonalData]
    [StringLength(50)]
    [Display(Name = "Nachname")]
    public string? LastName { get; set; } = "";

    [PersonalData]
    [StringLength(50)]
    [Display(Name = "Spitzname / Motto")]
    public string? NickName { get; set; } = "";

    [PersonalData]
    [DataType(DataType.Date)]
    [Display(Name = "Geburtstag")]
    public DateTime BirthDate { get; set; } = DateTime.Now;

    [PersonalData]
    [Display(Name = "Profilbild")]
    public byte[]? ProfilePicture { get; set; }

    [Display(Name = "Administrator")]
    public bool IsAdmin { get; set; } = false;

    [Display(Name = "Eigenschaft")]
    public float Power { get; set; } = 0.0F;

    [Display(Name = "Eigenschaftswert übernehmen von ...")]
    public int PowerLikePlayerId { get; set; }

    [Required]
    [Display(Name = "Mitgliedsstatus")]
    public MembershipType MembershipType { get; set; } = MembershipType.Member;

    [Display(Name = "Mannschaften")]
    public IList<TeamPlayer>? TeamPlayers { get; set; }
}
