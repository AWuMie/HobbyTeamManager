using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HobbyTeamManager.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HobbyTeamManager.EntityConfigurations;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasIndex(p => p.Emailaddress)
            .IsUnique();

        builder.Property(p => p.Emailaddress)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.PasswordSalt)
            .IsRequired();

        builder.Property(p => p.PasswordHash)
            .IsRequired()
            .HasMaxLength(64);

        // https://stackoverflow.com/questions/50823809/how-to-create-createdon-and-updatedon-using-ef-core-2-1-and-pomelo/57051561#57051561
        // ".IsRowVersion" kills it -> different behaviour between MSSQL and MYSQL!!!
        builder.Property(p => p.RowVersion)
            //.IsRowVersion()
            .ValueGeneratedOnAddOrUpdate();
        builder.Property(p => p.RowVersion)
            .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        builder.Property(p => p.RowVersion)
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        builder.Property(p => p.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.LastName)
            .HasMaxLength(50);

        builder.Property(p => p.NickName)
            .HasMaxLength(50);

        builder.Property(p => p.BirthDate)
            .HasColumnType("date");

        builder.HasOne<MembershipType>(p => p.MembershipType)
            .WithMany(mt => mt.Players)
            .HasForeignKey(p => p.MembershipTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Navigation(p => p.MembershipType)
            .AutoInclude();
    }
}
