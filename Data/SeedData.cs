using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new MySqlTestRazorContext(
            serviceProvider.GetRequiredService<DbContextOptions<MySqlTestRazorContext>>());

        // 2022-04-06: decided to NOT fill known players from Emerholzkicker in SeedData,
        // but provide the ability to "import" players via json file!
        // 2022-04-08: with the introduction of "Sites" the team colors can no longer be
        // "hard coded", but need to be set as properties of "Site".
        if (context == null ||
            context.MembershipTypes == null)
        {
            throw new ArgumentNullException("Null MySqlTestRazorContext");
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

        context.SaveChanges();
    }
}
