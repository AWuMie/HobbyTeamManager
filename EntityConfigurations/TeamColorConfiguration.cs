using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.EntityConfigurations;

public class TeamColorConfiguration : IEntityTypeConfiguration<TeamColor>
{
    public void Configure(EntityTypeBuilder<TeamColor> builder)
    {
        builder.Property(tc => tc.Name)
            .IsRequired()
            .HasMaxLength(10);
    }
}
