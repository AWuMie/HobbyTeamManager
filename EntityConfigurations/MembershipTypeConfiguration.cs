using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.EntityConfigurations;

public class MembershipTypeConfiguration : IEntityTypeConfiguration<MembershipType>
{
    // the order:
    // 1. table (name) overwrites (ToTable)
    // 2. primary keys (HasKey)
    // 3. properties
    // 4. relationships
    public void Configure(EntityTypeBuilder<MembershipType> builder)
    {
        builder.Property(mt => mt.MembershipTypeId)
            .HasColumnName("Id");

        builder.Property(mt => mt.Name)
            .IsRequired()
            .HasMaxLength(20);
    }
}
