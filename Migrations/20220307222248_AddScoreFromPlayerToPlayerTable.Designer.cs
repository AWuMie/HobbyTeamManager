// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using HobbyTeamManager.Data;

#nullable disable

namespace HobbyTeamManager.Migrations
{
    [DbContext(typeof(HobbyTeamManagerContext))]
    [Migration("20220307222248_AddScoreFromPlayerToPlayerTable")]
    partial class AddScoreFromPlayerToPlayerTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HobbyTeamManager.Models.MembershipType", b =>
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

            modelBuilder.Entity("HobbyTeamManager.Models.Player", b =>
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

                    b.HasIndex("ScoreFromPlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("HobbyTeamManager.Models.TeamColor", b =>
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

            modelBuilder.Entity("HobbyTeamManager.Models.Player", b =>
                {
                    b.HasOne("HobbyTeamManager.Models.Player", "ScoreFromPlayer")
                        .WithMany("ScoreForPlayers")
                        .HasForeignKey("ScoreFromPlayerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ScoreFromPlayer");
                });

            modelBuilder.Entity("HobbyTeamManager.Models.Player", b =>
                {
                    b.Navigation("ScoreForPlayers");
                });
#pragma warning restore 612, 618
        }
    }
}
