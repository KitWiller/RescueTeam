﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RescueTeam.DAL;

#nullable disable

namespace RescueTeam.DAL.Migrations
{
    [DbContext(typeof(RescueTeamDbContext))]
    [Migration("20230701141649_new2")]
    partial class new2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RescueTeam.DAL.Entities.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("MissionEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("MissionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MissionStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("RescueTeam.DAL.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Coordinates")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleID")
                        .HasColumnType("int")
                        .HasColumnName("VehicleID");

                    b.HasKey("Id");

                    b.HasIndex("VehicleID")
                        .IsUnique();

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("RescueTeam.DAL.Entities.TeamMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CurrentTeamId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CurrentTeamId");

                    b.ToTable("TeamMembers");
                });

            modelBuilder.Entity("RescueTeam.DAL.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NSeats")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("RescueTeam.DAL.Entities.Team", b =>
                {
                    b.HasOne("RescueTeam.DAL.Entities.Vehicle", "Vehicle")
                        .WithOne("AssignedTeam")
                        .HasForeignKey("RescueTeam.DAL.Entities.Team", "VehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("RescueTeam.DAL.Entities.TeamMember", b =>
                {
                    b.HasOne("RescueTeam.DAL.Entities.Team", "Team")
                        .WithMany("TeamMembers")
                        .HasForeignKey("CurrentTeamId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Team");
                });

            modelBuilder.Entity("RescueTeam.DAL.Entities.Team", b =>
                {
                    b.Navigation("TeamMembers");
                });

            modelBuilder.Entity("RescueTeam.DAL.Entities.Vehicle", b =>
                {
                    b.Navigation("AssignedTeam")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}