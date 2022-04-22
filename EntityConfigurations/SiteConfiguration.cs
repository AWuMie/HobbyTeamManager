using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.EntityConfigurations;

public class SiteConfiguration : IEntityTypeConfiguration<Site>
{
    public void Configure(EntityTypeBuilder<Site> builder)
    {
        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(s => s.Motto)
            .HasMaxLength(250);

        builder.Property(s => s.Headline)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(s => s.Headline2)
            .HasMaxLength(50);
    }
}
