using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.EntityConfigurations;

public class MatchDayConfiguration : IEntityTypeConfiguration<MatchDay>
{
    public void Configure(EntityTypeBuilder<MatchDay> builder)
    {
        builder.Property(md => md.Date)
            .IsRequired();

        builder.HasOne<Player>(md => md.BeerResponsible)
            .WithMany(p => p.BeerResponsibleOnMatchDays)
            .HasForeignKey(p => p.BeerResponsibleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Team>(md => md.TeamWhite)
            .WithOne(t => t.MatchDayForTeamWhite)
            .HasForeignKey<Team>(t => t.MatchDayIdForTeamWhite)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Team>(md => md.TeamRed)
            .WithOne(t => t.MatchDayForTeamRed)
            .HasForeignKey<Team>(t => t.MatchDayIdForTeamRed)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Season>(md => md.Season)
            .WithMany(s => s.MatchDays)
            .HasForeignKey(md => md.SeasonId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Navigation(md => md.Season)
            .AutoInclude();
    }
}
