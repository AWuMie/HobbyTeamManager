using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.EntityConfigurations;

public class TeamColorConfiguration : IEntityTypeConfiguration<TeamColor>
{
    public void Configure(EntityTypeBuilder<TeamColor> builder)
    {
        builder.Property(tc => tc.Id)
            .HasColumnName("Id");

        builder.Property(tc => tc.Name)
            .IsRequired()
            .HasMaxLength(10);
    }
}
