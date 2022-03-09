using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.EntityConfigurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasOne<TeamColor>(t => t.TeamColor)
            .WithMany(tc => tc.Teams)
            .HasForeignKey(t => t.TeamColorId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Navigation(t => t.TeamColor)
            .AutoInclude();
    }
}
