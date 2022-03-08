﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySqlTestRazor.Data;

#nullable disable

namespace MySqlTestRazor.Migrations
{
    [DbContext(typeof(MySqlTestRazorContext))]
    partial class MySqlTestRazorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MySqlTestRazor.Models.MatchDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("MatchDays");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.MembershipType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("MembershipTypes");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("MatchDayId")
                        .HasColumnType("int");

                    b.Property<int>("MembershipTypeId")
                        .HasColumnType("int");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("longblob");

                    b.Property<float>("Score")
                        .HasColumnType("float");

                    b.Property<int>("ScoreFromPlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchDayId")
                        .IsUnique();

                    b.HasIndex("MembershipTypeId");

                    b.HasIndex("ScoreFromPlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MatchOnDay")
                        .HasColumnType("int");

                    b.Property<int>("StartMonth")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.Property<int>("MatchDayIdForTeamRed")
                        .HasColumnType("int");

                    b.Property<int>("MatchDayIdForTeamWhite")
                        .HasColumnType("int");

                    b.Property<int>("TeamColorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchDayIdForTeamRed")
                        .IsUnique();

                    b.HasIndex("MatchDayIdForTeamWhite")
                        .IsUnique();

                    b.HasIndex("TeamColorId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.TeamColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("TeamColors");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.TeamPlayer", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("TeamId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("TeamPlayers");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.Player", b =>
                {
                    b.HasOne("MySqlTestRazor.Models.MatchDay", "BeerResponsibleOfMatchDay")
                        .WithOne("BeerResponsible")
                        .HasForeignKey("MySqlTestRazor.Models.Player", "MatchDayId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MySqlTestRazor.Models.MembershipType", "MembershipType")
                        .WithMany("Players")
                        .HasForeignKey("MembershipTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MySqlTestRazor.Models.Player", "ScoreFromPlayer")
                        .WithMany("ScoreForPlayers")
                        .HasForeignKey("ScoreFromPlayerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BeerResponsibleOfMatchDay");

                    b.Navigation("MembershipType");

                    b.Navigation("ScoreFromPlayer");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.Team", b =>
                {
                    b.HasOne("MySqlTestRazor.Models.MatchDay", "MatchDayForTeamRed")
                        .WithOne("TeamRed")
                        .HasForeignKey("MySqlTestRazor.Models.Team", "MatchDayIdForTeamRed")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MySqlTestRazor.Models.MatchDay", "MatchDayForTeamWhite")
                        .WithOne("TeamWhite")
                        .HasForeignKey("MySqlTestRazor.Models.Team", "MatchDayIdForTeamWhite")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MySqlTestRazor.Models.TeamColor", "TeamColor")
                        .WithMany("Teams")
                        .HasForeignKey("TeamColorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MatchDayForTeamRed");

                    b.Navigation("MatchDayForTeamWhite");

                    b.Navigation("TeamColor");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.TeamPlayer", b =>
                {
                    b.HasOne("MySqlTestRazor.Models.Player", "Player")
                        .WithMany("TeamPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MySqlTestRazor.Models.Team", "Team")
                        .WithMany("TeamPlayers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.MatchDay", b =>
                {
                    b.Navigation("BeerResponsible");

                    b.Navigation("TeamRed");

                    b.Navigation("TeamWhite");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.MembershipType", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.Player", b =>
                {
                    b.Navigation("ScoreForPlayers");

                    b.Navigation("TeamPlayers");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.Team", b =>
                {
                    b.Navigation("TeamPlayers");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.TeamColor", b =>
                {
                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
