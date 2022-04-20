﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySqlTestRazor.Data;

#nullable disable

namespace MySqlTestRazor.Migrations
{
    [DbContext(typeof(MySqlTestRazorContext))]
    [Migration("20220419082630_AddMenuPositionColumnToSiteTable")]
    partial class AddMenuPositionColumnToSiteTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MySqlTestRazor.Models.MatchDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BeerResponsibleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("SeasonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BeerResponsibleId");

                    b.HasIndex("SeasonId");

                    b.ToTable("MatchDays");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.MembershipType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("MembershipTypes");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.Password", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("Hash")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varbinary(60)");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Salt")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("Passwords");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<bool>("EmailAdressConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Emailaddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

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

                    b.HasKey("Id");

                    b.HasIndex("Emailaddress")
                        .IsUnique();

                    b.HasIndex("MembershipTypeId");

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

            modelBuilder.Entity("MySqlTestRazor.Models.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BgColorBody")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BgColorFooter")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BgColorHeader")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BgColorMain")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ConfirmationModeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("FgColorBody")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FgColorFooter")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FgColorHeader")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FgColorMain")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Logo")
                        .HasColumnType("longblob");

                    b.Property<int>("MenuPositionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Rules")
                        .HasColumnType("longtext");

                    b.Property<string>("TeamColor1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TeamColor2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.Property<int?>("MatchDayIdForTeamRed")
                        .HasColumnType("int");

                    b.Property<int?>("MatchDayIdForTeamWhite")
                        .HasColumnType("int");

                    b.Property<int?>("TeamColorId")
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
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("TeamColors");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.TeamPlayer", b =>
                {
                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("TeamId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("TeamPlayers");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.MatchDay", b =>
                {
                    b.HasOne("MySqlTestRazor.Models.Player", "BeerResponsible")
                        .WithMany("BeerResponsibleOnMatchDays")
                        .HasForeignKey("BeerResponsibleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MySqlTestRazor.Models.Season", "Season")
                        .WithMany("MatchDays")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("BeerResponsible");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.Password", b =>
                {
                    b.HasOne("MySqlTestRazor.Models.Player", "Player")
                        .WithOne("Password")
                        .HasForeignKey("MySqlTestRazor.Models.Password", "PlayerId");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.Player", b =>
                {
                    b.HasOne("MySqlTestRazor.Models.MembershipType", "MembershipType")
                        .WithMany("Players")
                        .HasForeignKey("MembershipTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MembershipType");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.Team", b =>
                {
                    b.HasOne("MySqlTestRazor.Models.MatchDay", "MatchDayForTeamRed")
                        .WithOne("TeamRed")
                        .HasForeignKey("MySqlTestRazor.Models.Team", "MatchDayIdForTeamRed")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MySqlTestRazor.Models.MatchDay", "MatchDayForTeamWhite")
                        .WithOne("TeamWhite")
                        .HasForeignKey("MySqlTestRazor.Models.Team", "MatchDayIdForTeamWhite")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MySqlTestRazor.Models.TeamColor", "TeamColor")
                        .WithMany("Teams")
                        .HasForeignKey("TeamColorId")
                        .OnDelete(DeleteBehavior.Restrict);

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
                    b.Navigation("TeamRed");

                    b.Navigation("TeamWhite");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.MembershipType", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.Player", b =>
                {
                    b.Navigation("BeerResponsibleOnMatchDays");

                    b.Navigation("Password");

                    b.Navigation("TeamPlayers");
                });

            modelBuilder.Entity("MySqlTestRazor.Models.Season", b =>
                {
                    b.Navigation("MatchDays");
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
