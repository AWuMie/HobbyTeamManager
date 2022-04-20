using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.EntityConfigurations;

public class TeamPlayerConfiguration : IEntityTypeConfiguration<TeamPlayer>
{
    public void Configure(EntityTypeBuilder<TeamPlayer> builder)
    {
        builder.HasKey(tp => new { tp.TeamId, tp.PlayerId });

        builder.HasOne<Player>(tp => tp.Player)
            .WithMany(p => p.TeamPlayers)
            .HasForeignKey(tp => tp.PlayerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Team>(tp => tp.Team)
            .WithMany(t => t.TeamPlayers)
            .HasForeignKey(tp => tp.TeamId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
