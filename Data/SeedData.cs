using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Models;
using static HobbyTeamManager.Utilities.PasswordCryptography;

namespace HobbyTeamManager.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new HobbyTeamManagerContext(
            serviceProvider.GetRequiredService<DbContextOptions<HobbyTeamManagerContext>>());

        // 2022-04-06: decided to NOT fill known players from Emerholzkicker in SeedData,
        // but provide the ability to "import" players via json file!
        // 2022-04-08: with the introduction of "Sites" the team colors can no longer be
        // "hard coded", but need to be set as properties of "Site".
        if (context == null ||
            context.MembershipTypes == null ||
            context.Players == null)
        {
            throw new ArgumentNullException("Null HobbyTeamManagerContext");
        }

        // Look for seeded MembershipTypes data.
        if (!context.MembershipTypes.Any())
        {
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
        }

        // seed THE administrator player
        if (!context.Players.Any())
        {
            var admin = new Player
            {
                FirstName = "Admin",
                Emailaddress = "admin@hobbyteammanager.com",
                EmailAdressConfirmed = true,
                IsAdmin = true,
                MembershipTypeId = 1
            };
            HashSalt hs = GenerateHashSaltFromPassword("Admin.12");
            admin.PasswordHash = hs.hash;
            admin.PasswordSalt = hs.salt;

            context.Players.Add(admin);
        }

        try
        {
            context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new InvalidOperationException($"DbUpdateConcurrencyException occurred creating new admin user in SeedData.cs.");
        }
        catch (DbUpdateException)
        {
            throw new InvalidOperationException($"DbUpdateException occurred creating new admin user in SeedData.cs.");
        }
    }
}
