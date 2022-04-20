﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.EntityConfigurations;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasIndex(p => p.Emailaddress)
            .IsUnique();

        builder.Property(p => p.Emailaddress)
            .IsRequired()
            .HasMaxLength(50);

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
