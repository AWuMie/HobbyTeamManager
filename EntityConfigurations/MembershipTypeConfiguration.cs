using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.EntityConfigurations;

public class MembershipTypeConfiguration : IEntityTypeConfiguration<MembershipType>
{
    // the order:
    // 1. table (name) overwrites (ToTable)
    // 2. primary keys (HasKey)
    // 3. properties
    // 4. relationships
    public void Configure(EntityTypeBuilder<MembershipType> builder)
    {
        builder.Property(mt => mt.Id)
            .HasColumnName("Id");

        builder.Property(mt => mt.Name)
            .IsRequired()
            .HasMaxLength(20);
    }
}
