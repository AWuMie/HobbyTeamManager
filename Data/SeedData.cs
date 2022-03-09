using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new MySqlTestRazorContext(
            serviceProvider.GetRequiredService<DbContextOptions<MySqlTestRazorContext>>());

        //if (context == null || context.Players == null)
        if (context == null ||
            context.MembershipTypes == null ||
            context.TeamColors == null ||
            context.Players == null)
        {
            throw new ArgumentNullException("Null MySqlTestRazorContext");
        }

        // Look for any data.
        if (context.MembershipTypes.Any())
        {
            return;   // DB has already been seeded
        }

        context.MembershipTypes.AddRange(
            new MembershipType
            {
                Name = MembershipType.Member
            },

            new MembershipType
            {
                Name = MembershipType.Guest
            },

            new MembershipType
            {
                Name = MembershipType.Ex
            }
        );

        context.TeamColors.AddRange(
            new TeamColor
            {
                Name = TeamColor.Weiss
            },

            new TeamColor
            {
                Name = TeamColor.Rot
            }
        );
        context.SaveChanges();

        string pathActive = "C:\\Users\\Achim\\OneDrive\\Bilder\\TEMP - Emerholzkicker\\Aktiv\\";
        string pathGuest = "C:\\Users\\Achim\\OneDrive\\Bilder\\TEMP - Emerholzkicker\\Gast\\";
        string pathEx = "C:\\Users\\Achim\\OneDrive\\Bilder\\TEMP - Emerholzkicker\\Ex\\";

        var member = context.MembershipTypes
            .Where(ms => ms.Name == MembershipType.Member)
            .First();

        var guest = context.MembershipTypes
            .Where(ms => ms.Name == MembershipType.Guest)
            .First();

        var ex = context.MembershipTypes
            .Where(ms => ms.Name == MembershipType.Ex)
            .First();
        
        if (member == null || guest == null || ex == null)
        {
            throw new NullReferenceException();
        }

        context.Players.AddRange(
            new Player
            {
                FirstName = "Fabian",
                LastName = "Hoger",
                NickName = "Fabse",
                ProfilePicture = File.ReadAllBytes(pathActive + "Fabi.png"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Stefan",
                LastName = "Pörtner",
                NickName = "Schdievinho",
                ProfilePicture = File.ReadAllBytes(pathActive + "08Praesi0.JPG"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Bernd",
                LastName = "Mutter",
                NickName = "Berndinho",
                ProfilePicture = File.ReadAllBytes(pathActive + "Bernd17.jpg"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Marcus",
                LastName = "Schroweg",
                NickName = "Marcüs",
                ProfilePicture = File.ReadAllBytes(pathActive + "Marcues.jpg"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Michael",
                LastName = "Hoger",
                NickName = "Hoginho",
                ProfilePicture = File.ReadAllBytes(pathActive + "Hogi.jpg"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Mathias",
                LastName = "Mienhardt",
                NickName = "Matzelinho",
                ProfilePicture = File.ReadAllBytes(pathActive + "Matze.png"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Giuseppe",
                LastName = "Vocino",
                NickName = "Pino",
                ProfilePicture = File.ReadAllBytes(pathActive + "Pino21.jpg"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Martin",
                LastName = "Thaler",
                NickName = "Thalersmaddin",
                ProfilePicture = File.ReadAllBytes(pathActive + "Maddin1.jpg"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Volker",
                LastName = "Kischlat",
                NickName = "Kischi",
                ProfilePicture = File.ReadAllBytes(pathActive + "VolkerK.jpg"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Ogün",
                LastName = "Ferres",
                NickName = "Eugen",
                ProfilePicture = File.ReadAllBytes(pathActive + "Ogun.jpg"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Andreas",
                LastName = "Braiger",
                NickName = "DickAndy",
                ProfilePicture = File.ReadAllBytes(pathActive + "08Andi0.jpg"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Götz",
                LastName = "Kallweit",
                NickName = "Götz04",
                ProfilePicture = File.ReadAllBytes(pathActive + "08Goetz0.jpg"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Georg",
                LastName = "Schmidt",
                NickName = "Jorginho",
                ProfilePicture = File.ReadAllBytes(pathActive + "08Georg3.jpg"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Detlef",
                LastName = "König",
                NickName = "Det",
                ProfilePicture = File.ReadAllBytes(pathActive + "08Det2.jpg"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Michael",
                LastName = "Haubold",
                NickName = "Haubinho",
                IsAdmin = true,
                ProfilePicture = File.ReadAllBytes(pathActive + "08Haubi0.jpg"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Marcus",
                LastName = "Zaiß",
                NickName = "Zacke",
                ProfilePicture = File.ReadAllBytes(pathActive + "Zaiss.jpg"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Kay",
                LastName = "Kischlat",
                NickName = "Der Schnelle Kay",
                IsAdmin = true,
                ProfilePicture = File.ReadAllBytes(pathActive + "Kay.jpg"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Achim",
                LastName = "Mienhardt",
                NickName = "Achimedes",
                IsAdmin = true,
                ProfilePicture = File.ReadAllBytes(pathActive + "Achim.jpg"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Garry",
                LastName = "Radig",
                NickName = "Garry",
                ProfilePicture = File.ReadAllBytes(pathActive + "Garryfes.jpg"),
                MembershipType = member
            },

            new Player
            {
                FirstName = "Volodymyr",
                LastName = "Kashyrin",
                NickName = "Waldi",
                ProfilePicture = File.ReadAllBytes(pathGuest + "Waldi.jpg"),
                MembershipType = guest
            },

            new Player
            {
                FirstName = "Sven",
                LastName = "Kallweit",
                NickName = "",
                ProfilePicture = File.ReadAllBytes(pathGuest + "SvenK.jpg"),
                MembershipType = guest
            },

            new Player
            {
                FirstName = "Jörg",
                LastName = "Zimmermann",
                NickName = "Zimmizieh",
                ProfilePicture = File.ReadAllBytes(pathGuest + "jozi1.jpg"),
                MembershipType = guest
            },

            new Player
            {
                FirstName = "Ralf",
                LastName = "Maier",
                NickName = "",
                ProfilePicture = File.ReadAllBytes(pathGuest + "Ralf-Maier-Trainer.jpg"),
                MembershipType = guest
            },

            new Player
            {
                FirstName = "Marc",
                LastName = "Hoger",
                NickName = "",
                ProfilePicture = File.ReadAllBytes(pathGuest + "MARCHOGI.jpg"),
                MembershipType = guest
            },

            new Player
            {
                FirstName = "Daniel",
                LastName = "Schroweg",
                NickName = "Dani",
                ProfilePicture = File.ReadAllBytes(pathGuest + "DSchr.jpg"),
                MembershipType = guest
            },

            new Player
            {
                FirstName = "Nicolai",
                LastName = "Mienhardt",
                NickName = "Nico",
                ProfilePicture = File.ReadAllBytes(pathGuest + "08MatzKid.jpg"),
                MembershipType = guest
            },

            new Player
            {
                FirstName = "Andreas",
                LastName = "Pohl",
                NickName = "Andy",
                ProfilePicture = File.ReadAllBytes(pathGuest + "AndyPohl.jpg"),
                MembershipType = guest
            },

            new Player
            {
                FirstName = "Johannes",
                LastName = "Bach",
                NickName = "",
                ProfilePicture = File.ReadAllBytes(pathGuest + "JohannesBach.jpg"),
                MembershipType = guest
            },

            new Player
            {
                FirstName = "Michael",
                LastName = "Müller",
                NickName = "Mike",
                ProfilePicture = File.ReadAllBytes(pathGuest + "MikeMueller.jpg"),
                MembershipType = guest
            },

            new Player
            {
                FirstName = "Senad",
                LastName = "",
                NickName = "",
                ProfilePicture = File.ReadAllBytes(pathGuest + "Senad.jpg"),
                MembershipType = guest
            },

            new Player
            {
                FirstName = "Stjepan",
                LastName = "Kucelj",
                NickName = "",
                ProfilePicture = File.ReadAllBytes(pathGuest + "Kucelj_1.jpg"),
                MembershipType = guest
            },

            new Player
            {
                FirstName = "Heiko",
                LastName = "",
                NickName = "",
                ProfilePicture = File.ReadAllBytes(pathGuest + "MUSTER.jpg"),
                MembershipType = guest
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Bernd  1998 - 2002",
                ProfilePicture = File.ReadAllBytes(pathEx + "AlteHerrenbernd.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Werner  1999 - 2006",
                ProfilePicture = File.ReadAllBytes(pathEx + "alteHerrenwerner0.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Uwe  2000 - 2006",
                ProfilePicture = File.ReadAllBytes(pathEx + "AlteHerrenuwe.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Peter  1997 - 2005",
                ProfilePicture = File.ReadAllBytes(pathEx + "peter.jpg"),
                MembershipType = ex
            },


            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Hans  2002 - 2005",
                ProfilePicture = File.ReadAllBytes(pathEx + "AlteHerrenhansher.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Fevzi  1999 - 2005",
                ProfilePicture = File.ReadAllBytes(pathEx + "alteHerrenfevz.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Platzi Schweyerle  2004",
                ProfilePicture = File.ReadAllBytes(pathEx + "04JSchwey.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Mehmet  1999 - 2009",
                ProfilePicture = File.ReadAllBytes(pathEx + "Mehmet.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "Fabiano",
                LastName = "",
                NickName = "Fabiano Italiano",
                ProfilePicture = File.ReadAllBytes(pathEx + "Fabiano.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "Volker",
                LastName = "Beck",
                NickName = "Volker",
                ProfilePicture = File.ReadAllBytes(pathEx + "AlteHerrenbeckvo2.jpg"),
                MembershipType = ex
            },


            new Player
            {
                FirstName = "Martin",
                LastName = "Sommer",
                NickName = "Martinho",
                ProfilePicture = File.ReadAllBytes(pathEx + "08Martin3.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "Oliver",
                LastName = "Haubold",
                NickName = "Olli",
                ProfilePicture = File.ReadAllBytes(pathEx + "08Olli2.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Gerhard  1996 - 2001 / 2004 - 2005",
                ProfilePicture = File.ReadAllBytes(pathEx + "gerhard.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Micha  1999 - 2004",
                ProfilePicture = File.ReadAllBytes(pathEx + "FKMB1.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "",
                LastName = "Jung",
                NickName = "Micha Jung  2000 - 2004",
                ProfilePicture = File.ReadAllBytes(pathEx + "FKJung1.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Alexej Wisla Krakow  1998 - 2004",
                ProfilePicture = File.ReadAllBytes(pathEx + "FKAlex1.jpg"),
                MembershipType = ex
            },


            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Hans  2000 - 2004",
                ProfilePicture = File.ReadAllBytes(pathEx + "08HK.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Labo 1998",
                ProfilePicture = File.ReadAllBytes(pathEx + "08Labo1.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Jürgen  1996",
                ProfilePicture = File.ReadAllBytes(pathEx + "08JW.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Walter  2005 - 2006",
                ProfilePicture = File.ReadAllBytes(pathEx + "08Walter.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Matze Böck",
                ProfilePicture = File.ReadAllBytes(pathEx + "08Boeck.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "Uwe",
                LastName = "Beck",
                NickName = "Uns Uwe  1997 - 2010",
                ProfilePicture = File.ReadAllBytes(pathEx + "08UBeck.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "NÜ",
                LastName = "Ex-CFC-Torwart",
                NickName = "",
                ProfilePicture = File.ReadAllBytes(pathEx + "nue.jpg"),
                MembershipType = ex
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Orti",
                ProfilePicture = File.ReadAllBytes(pathEx + "ortl.jpg"),
                MembershipType = ex
            }
        );
        context.SaveChanges();
    }
}

/*MySqlException: Cannot add or update a child row: a foreign key constraint fails
 * (`TestDB`.`Players`,
 * CONSTRAINT `FK_Players_MatchDays_MatchDayId` 
 * FOREIGN KEY (`MatchDayId`)
 * REFERENCES `MatchDays` (`Id`))
*/
/*MySqlException: Cannot add or update a child row: a foreign key constraint fails
 * (`TestDB`.`Players`,
 * CONSTRAINT `FK_Players_MatchDays_MatchDayId`
 * FOREIGN KEY (`MatchDayId`)
 * REFERENCES `MatchDays` (`Id`))
*/
