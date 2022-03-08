using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.EntityConfigurations;

public class MatchDayConfiguration : IEntityTypeConfiguration<MatchDay>
{
    public void Configure(EntityTypeBuilder<MatchDay> builder)
    {
        builder.Property(md => md.DateTime)
            .IsRequired();

        builder.HasOne<Player>(md => md.BeerResponsible)
            .WithOne(p => p.BeerResponsibleOfMatchDay)
            .HasForeignKey<Player>(p => p.MatchDayId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Team>(md => md.TeamWhite)
            .WithOne(t => t.MatchDayForTeamWhite)
            .HasForeignKey<Team>(t => t.MatchDayIdForTeamWhite)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Team>(md => md.TeamRed)
            .WithOne(t => t.MatchDayForTeamRed)
            .HasForeignKey<Team>(t => t.MatchDayIdForTeamRed)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
