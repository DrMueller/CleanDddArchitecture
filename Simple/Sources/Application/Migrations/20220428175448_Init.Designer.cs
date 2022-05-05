﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Contexts.Implementation;

namespace Mmu.CleanDddSimple.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220428175448_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mmu.CleanDddSimple.Areas.Meetings.Domain.Models.Agenda", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("MeetingId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId")
                        .IsUnique();

                    b.ToTable("Agenda", "Meetings");
                });

            modelBuilder.Entity("Mmu.CleanDddSimple.Areas.Meetings.Domain.Models.AgendaPoint", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AgendaId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId");

                    b.ToTable("AgendaPoint", "Meetings");
                });

            modelBuilder.Entity("Mmu.CleanDddSimple.Areas.Meetings.Domain.Models.Meeting", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("MeetingType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Meeting", "Meetings");
                });

            modelBuilder.Entity("Mmu.CleanDddSimple.Areas.Meetings.Domain.Models.Participant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("MeetingId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId");

                    b.ToTable("Participant", "Meetings");
                });

            modelBuilder.Entity("Mmu.CleanDddSimple.Areas.Meetings.Domain.Models.Agenda", b =>
                {
                    b.HasOne("Mmu.CleanDddSimple.Areas.Meetings.Domain.Models.Meeting", null)
                        .WithOne("Agenda")
                        .HasForeignKey("Mmu.CleanDddSimple.Areas.Meetings.Domain.Models.Agenda", "MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mmu.CleanDddSimple.Areas.Meetings.Domain.Models.AgendaPoint", b =>
                {
                    b.HasOne("Mmu.CleanDddSimple.Areas.Meetings.Domain.Models.Agenda", null)
                        .WithMany("Points")
                        .HasForeignKey("AgendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Mmu.CleanDddSimple.Areas.Meetings.Domain.Models.AgendaPointDescription", "Description", b1 =>
                        {
                            b1.Property<long>("AgendaPointId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)");

                            b1.HasKey("AgendaPointId");

                            b1.ToTable("AgendaPoint", "Meetings");

                            b1.WithOwner()
                                .HasForeignKey("AgendaPointId");
                        });

                    b.Navigation("Description")
                        .IsRequired();
                });

            modelBuilder.Entity("Mmu.CleanDddSimple.Areas.Meetings.Domain.Models.Participant", b =>
                {
                    b.HasOne("Mmu.CleanDddSimple.Areas.Meetings.Domain.Models.Meeting", null)
                        .WithMany("Participants")
                        .HasForeignKey("MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mmu.CleanDddSimple.Areas.Meetings.Domain.Models.Agenda", b =>
                {
                    b.Navigation("Points");
                });

            modelBuilder.Entity("Mmu.CleanDddSimple.Areas.Meetings.Domain.Models.Meeting", b =>
                {
                    b.Navigation("Agenda")
                        .IsRequired();

                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
