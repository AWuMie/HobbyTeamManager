using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new MySqlTestRazorContext(
            serviceProvider.GetRequiredService<DbContextOptions<MySqlTestRazorContext>>());

        if (context == null || context.Players == null)
        {
            throw new ArgumentNullException("Null MySqlTestRazorContext");
        }

        // Look for any players.
        if (context.Players.Any())
        {
            return;   // DB has already been seeded
        }

        string pathActive = "C:\\Users\\Achim\\OneDrive\\Bilder\\TEMP - Emerholzkicker\\Aktiv\\";
        string pathGuest = "C:\\Users\\Achim\\OneDrive\\Bilder\\TEMP - Emerholzkicker\\Gast\\";
        string pathEx = "C:\\Users\\Achim\\OneDrive\\Bilder\\TEMP - Emerholzkicker\\Ex\\";

        context.Players.AddRange(
            new Player
            {
                FirstName = "Fabian",
                LastName = "Hoger",
                NickName = "Fabse",
                ProfilePicture = File.ReadAllBytes(pathActive + "Fabi.png"),
            },

            new Player
            {
                FirstName = "Stefan",
                LastName = "Pörtner",
                NickName = "Schdievinho",
                ProfilePicture = File.ReadAllBytes(pathActive + "08Praesi0.JPG"),
            },

            new Player
            {
                FirstName = "Bernd",
                LastName = "Mutter",
                NickName = "Berndinho",
                ProfilePicture = File.ReadAllBytes(pathActive + "Bernd17.jpg"),
            },

            new Player
            {
                FirstName = "Marcus",
                LastName = "Schroweg",
                NickName = "Marcüs",
                ProfilePicture = File.ReadAllBytes(pathActive + "Marcues.jpg"),
            },

            new Player
            {
                FirstName = "Michael",
                LastName = "Hoger",
                NickName = "Hoginho",
                ProfilePicture = File.ReadAllBytes(pathActive + "Hogi.jpg"),
            },

            new Player
            {
                FirstName = "Mathias",
                LastName = "Mienhardt",
                NickName = "Matzelinho",
                ProfilePicture = File.ReadAllBytes(pathActive + "Matze.png"),
            },

            new Player
            {
                FirstName = "Giuseppe",
                LastName = "Vocino",
                NickName = "Pino",
                ProfilePicture = File.ReadAllBytes(pathActive + "Pino21.jpg"),
            },

            new Player
            {
                FirstName = "Martin",
                LastName = "Thaler",
                NickName = "Thalersmaddin",
                ProfilePicture = File.ReadAllBytes(pathActive + "Maddin1.jpg"),
            },

            new Player
            {
                FirstName = "Volker",
                LastName = "Kischlat",
                NickName = "Kischi",
                ProfilePicture = File.ReadAllBytes(pathActive + "VolkerK.jpg"),
            },

            new Player
            {
                FirstName = "Ogün",
                LastName = "Ferres",
                NickName = "Eugen",
                ProfilePicture = File.ReadAllBytes(pathActive + "Ogun.jpg"),
            },

            new Player
            {
                FirstName = "Andreas",
                LastName = "Braiger",
                NickName = "DickAndy",
                ProfilePicture = File.ReadAllBytes(pathActive + "08Andi0.jpg"),
            },

            new Player
            {
                FirstName = "Götz",
                LastName = "Kallweit",
                NickName = "Götz04",
                ProfilePicture = File.ReadAllBytes(pathActive + "08Goetz0.jpg"),
            },

            new Player
            {
                FirstName = "Georg",
                LastName = "Schmidt",
                NickName = "Jorginho",
                ProfilePicture = File.ReadAllBytes(pathActive + "08Georg3.jpg"),
            },

            new Player
            {
                FirstName = "Detlef",
                LastName = "König",
                NickName = "Det",
                ProfilePicture = File.ReadAllBytes(pathActive + "08Det2.jpg"),
            },

            new Player
            {
                FirstName = "Michael",
                LastName = "Haubold",
                NickName = "Haubinho",
                IsAdmin = true,
                ProfilePicture = File.ReadAllBytes(pathActive + "08Haubi0.jpg"),
            },

            new Player
            {
                FirstName = "Marcus",
                LastName = "Zaiß",
                NickName = "Zacke",
                ProfilePicture = File.ReadAllBytes(pathActive + "Zaiss.jpg"),
            },

            new Player
            {
                FirstName = "Kay",
                LastName = "Kischlat",
                NickName = "Der Schnelle Kay",
                IsAdmin = true,
                ProfilePicture = File.ReadAllBytes(pathActive + "Kay.jpg"),
            },

            new Player
            {
                FirstName = "Achim",
                LastName = "Mienhardt",
                NickName = "Achimedes",
                IsAdmin = true,
                ProfilePicture = File.ReadAllBytes(pathActive + "Achim.jpg"),
            },

            new Player
            {
                FirstName = "Garry",
                LastName = "Radig",
                NickName = "Garry",
                ProfilePicture = File.ReadAllBytes(pathActive + "Garryfes.jpg"),
            },

            new Player
            {
                FirstName = "Volodymyr",
                LastName = "Kashyrin",
                NickName = "Waldi",
                MembershipType = MembershipType.Guest,
                ProfilePicture = File.ReadAllBytes(pathGuest + "Waldi.jpg"),
            },

            new Player
            {
                FirstName = "Sven",
                LastName = "Kallweit",
                NickName = "",
                MembershipType = MembershipType.Guest,
                ProfilePicture = File.ReadAllBytes(pathGuest + "SvenK.jpg"),
            },

            new Player
            {
                FirstName = "Jörg",
                LastName = "Zimmermann",
                NickName = "Zimmizieh",
                MembershipType = MembershipType.Guest,
                ProfilePicture = File.ReadAllBytes(pathGuest + "jozi1.jpg"),
            },

            new Player
            {
                FirstName = "Ralf",
                LastName = "Maier",
                NickName = "",
                MembershipType = MembershipType.Guest,
                ProfilePicture = File.ReadAllBytes(pathGuest + "Ralf-Maier-Trainer.jpg"),
            },

            new Player
            {
                FirstName = "Marc",
                LastName = "Hoger",
                NickName = "",
                MembershipType = MembershipType.Guest,
                ProfilePicture = File.ReadAllBytes(pathGuest + "MARCHOGI.jpg"),
            },

            new Player
            {
                FirstName = "Daniel",
                LastName = "Schroweg",
                NickName = "Dani",
                MembershipType = MembershipType.Guest,
                ProfilePicture = File.ReadAllBytes(pathGuest + "DSchr.jpg"),
            },

            new Player
            {
                FirstName = "Nicolai",
                LastName = "Mienhardt",
                NickName = "Nico",
                MembershipType = MembershipType.Guest,
                ProfilePicture = File.ReadAllBytes(pathGuest + "08MatzKid.jpg"),
            },

            new Player
            {
                FirstName = "Andreas",
                LastName = "Pohl",
                NickName = "Andy",
                MembershipType = MembershipType.Guest,
                ProfilePicture = File.ReadAllBytes(pathGuest + "AndyPohl.jpg"),
            },

            new Player
            {
                FirstName = "Johannes",
                LastName = "Bach",
                NickName = "",
                MembershipType = MembershipType.Guest,
                ProfilePicture = File.ReadAllBytes(pathGuest + "JohannesBach.jpg"),
            },

            new Player
            {
                FirstName = "Michael",
                LastName = "Müller",
                NickName = "Mike",
                MembershipType = MembershipType.Guest,
                ProfilePicture = File.ReadAllBytes(pathGuest + "MikeMueller.jpg"),
            },

            new Player
            {
                FirstName = "Senad",
                LastName = "",
                NickName = "",
                MembershipType = MembershipType.Guest,
                ProfilePicture = File.ReadAllBytes(pathGuest + "Senad.jpg"),
            },

            new Player
            {
                FirstName = "Stjepan",
                LastName = "Kucelj",
                NickName = "",
                MembershipType = MembershipType.Guest,
                ProfilePicture = File.ReadAllBytes(pathGuest + "Kucelj_1.jpg"),
            },

            new Player
            {
                FirstName = "Heiko",
                LastName = "",
                NickName = "",
                MembershipType = MembershipType.Guest,
                ProfilePicture = File.ReadAllBytes(pathGuest + "MUSTER.jpg"),
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Bernd  1998 - 2002",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "AlteHerrenbernd.jpg"),
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Werner  1999 - 2006",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "alteHerrenwerner0.jpg"),
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Uwe  2000 - 2006",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "AlteHerrenuwe.jpg"),
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Peter  1997 - 2005",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "peter.jpg"),
            },


            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Hans  2002 - 2005",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "AlteHerrenhansher.jpg"),
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Fevzi  1999 - 2005",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "alteHerrenfevz.jpg"),
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Platzi Schweyerle  2004",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "04JSchwey.jpg"),
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Mehmet  1999 - 2009",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "Mehmet.jpg"),
            },

            new Player
            {
                FirstName = "Fabiano",
                LastName = "",
                NickName = "Fabiano Italiano",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "Fabiano.jpg"),
            },

            new Player
            {
                FirstName = "Volker",
                LastName = "Beck",
                NickName = "Volker",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "AlteHerrenbeckvo2.jpg"),
            },


            new Player
            {
                FirstName = "Martin",
                LastName = "Sommer",
                NickName = "Martinho",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "08Martin3.jpg"),
            },

            new Player
            {
                FirstName = "Oliver",
                LastName = "Haubold",
                NickName = "Olli",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "08Olli2.jpg"),
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Gerhard  1996 - 2001 / 2004 - 2005",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "gerhard.jpg"),
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Micha  1999 - 2004",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "FKMB1.jpg"),
            },

            new Player
            {
                FirstName = "",
                LastName = "Jung",
                NickName = "Micha Jung  2000 - 2004",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "FKJung1.jpg"),
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Alexej Wisla Krakow  1998 - 2004",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "FKAlex1.jpg"),
            },


            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Hans  2000 - 2004",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "08HK.jpg"),
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Labo 1998",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "08Labo1.jpg"),
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Jürgen  1996",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "08JW.jpg"),
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Walter  2005 - 2006",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "08Walter.jpg"),
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Matze Böck",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "08Boeck.jpg"),
            },

            new Player
            {
                FirstName = "Uwe",
                LastName = "Beck",
                NickName = "Uns Uwe  1997 - 2010",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "08UBeck.jpg"),
            },

            new Player
            {
                FirstName = "NÜ",
                LastName = "Ex-CFC-Torwart",
                NickName = "",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "nue.jpg"),
            },

            new Player
            {
                FirstName = "",
                LastName = "",
                NickName = "Orti",
                MembershipType = MembershipType.Ex,
                ProfilePicture = File.ReadAllBytes(pathEx + "ortl.jpg"),
            }
        );
        context.SaveChanges();
    }
}
