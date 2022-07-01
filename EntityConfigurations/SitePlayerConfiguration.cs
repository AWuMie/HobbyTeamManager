using HobbyTeamManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HobbyTeamManager.EntityConfigurations;

public class SitePlayerConfiguration : IEntityTypeConfiguration<SitePlayer>
{
    public void Configure(EntityTypeBuilder<SitePlayer> builder)
    {
        builder.HasKey(sp => new { sp.SiteId, sp.PlayerId });

        builder.HasOne<Player>(sp => sp.Player)
            .WithMany(p => p.SitePlayers)
            .HasForeignKey(sp => sp.PlayerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Site>(sp => sp.Site)
            .WithMany(s => s.SitePlayers)
            .HasForeignKey(sp => sp.SiteId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
