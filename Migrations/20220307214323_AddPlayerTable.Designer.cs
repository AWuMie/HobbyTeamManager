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
    [Migration("20220307214323_AddPlayerTable")]
    partial class AddPlayerTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("longblob");

                    b.Property<float>("Score")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Players");
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
#pragma warning restore 612, 618
        }
    }
}
