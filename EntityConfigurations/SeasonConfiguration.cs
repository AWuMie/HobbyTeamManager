using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.EntityConfigurations;

public class SeasonConfiguration : IEntityTypeConfiguration<Season>
{
    public void Configure(EntityTypeBuilder<Season> builder)
    {
        builder.HasOne<Site>(season => season.Site)
            .WithMany(site => site.Seasons)
            .HasForeignKey(season => season.SiteId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Navigation(season => season.Site)
            .AutoInclude();
    }
}
