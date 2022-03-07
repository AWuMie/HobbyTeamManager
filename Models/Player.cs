﻿using Microsoft.AspNetCore.Identity;
//using System.ComponentModel.DataAnnotations;

namespace MySqlTestRazor.Models;

// DONE: replace by db table with exactly those three values/names
//public enum MembershipType
//{
//    Member = 1,
//    Guest = 2,
//    Ex = 3
//}

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
    // DONE: rename to "Score"
    public float Score { get; set; } = 0.0F;

    // only valid for guest-players which don't have an
    // automatically calculated score
    // TODO: setup as one to one relationship!!!
    // public int PowerLikePlayerId { get; set; }

    // public MembershipType MembershipType { get; set; } = MembershipType.Member;

    // many to many releationship between teams and players:
    // a team has many players
    // and
    // a player can play in many teams (a team is valid for one matchday)
    //public ICollection<TeamPlayer>? TeamPlayers { get; set; }

    // one to one relationship with MatchDay to cover the beer-responsible
    //public int MatchDayId { get; set; } = 0;
    //public MatchDay? BeerResponsibleOfMatchDay { get; set; }
}
