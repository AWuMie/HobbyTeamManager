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
        if (context == null ||
            context.MembershipTypes == null ||
            context.TeamColors == null)
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

        // Look for seeded TeamColors data.
        if (!context.TeamColors.Any())
        {
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
        }

        context.SaveChanges();
    }
}
