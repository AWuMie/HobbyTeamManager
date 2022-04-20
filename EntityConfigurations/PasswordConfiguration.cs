using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.EntityConfigurations
{
    public class PasswordConfiguration : IEntityTypeConfiguration<Password>
    {
        public void Configure(EntityTypeBuilder<Password> builder)
        {
            builder.Property(p => p.Salt)
                .IsRequired();

            builder.Property(p => p.Hash)
                .IsRequired()
                .HasMaxLength(60);
        }
    }
}
