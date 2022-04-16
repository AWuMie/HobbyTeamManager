using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.EntityConfigurations;

public class SiteConfiguration : IEntityTypeConfiguration<Site>
{
    public void Configure(EntityTypeBuilder<Site> builder)
    {
        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}
