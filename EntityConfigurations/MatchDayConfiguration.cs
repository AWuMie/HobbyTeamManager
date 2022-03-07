using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.EntityConfigurations;

public class MatchDayConfiguration : IEntityTypeConfiguration<MatchDay>
{
    public void Configure(EntityTypeBuilder<MatchDay> builder)
    {
        // table (name) overwrites
        // primary keys
        // properties
        builder.Property(md => md.DateTime)
            .IsRequired();

        //builder.Property(md => md.TeamWhite)
        //    .IsRequired();

        //builder.Property(md => md.TeamRed)
        //    .IsRequired();

        // relationships
        builder.HasOne<Player>(md => md.BeerResponsible)
            .WithOne(br => br.BeerResponsibleOfMatchDay)
            .HasForeignKey<Player>(br => br.MatchDayId);

        builder.HasOne<Team>(md => md.TeamWhite)
            .WithOne(t => t.MatchDayForTeamWhite)
            .HasForeignKey<Team>(t => t.MatchDayIdForTeamWhite);

        builder.HasOne<Team>(md => md.TeamRed)
            .WithOne(t => t.MatchDayForTeamRed)
            .HasForeignKey<Team>(t => t.MatchDayIdForTeamRed);
    }
}
