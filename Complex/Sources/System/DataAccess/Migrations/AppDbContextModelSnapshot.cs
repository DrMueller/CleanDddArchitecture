﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mmu.CleanDdd.DataAccess.Areas.DbContexts.Contexts.Implementation;

namespace Mmu.CleanDdd.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mmu.CleanDdd.Individuals.Domain.Areas.Models.Individual", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Individual", "Individuals");
                });

            modelBuilder.Entity("Mmu.CleanDdd.Individuals.Domain.Areas.Models.Organisation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Organisation", "Individuals");
                });

            modelBuilder.Entity("Mmu.CleanDdd.Meetings.Domain.Areas.Models.Meeting", b =>
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

            modelBuilder.Entity("Mmu.CleanDdd.Meetings.Domain.Areas.Models.Meeting", b =>
                {
                    b.OwnsOne("Mmu.CleanDdd.Meetings.Domain.Areas.Models.Agenda", "Agenda", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("CreatedDate")
                                .HasColumnType("datetime2");

                            b1.Property<long>("MeetingId")
                                .HasColumnType("bigint");

                            b1.Property<DateTime>("UpdatedDate")
                                .HasColumnType("datetime2");

                            b1.HasKey("Id");

                            b1.HasIndex("MeetingId")
                                .IsUnique();

                            b1.ToTable("Agenda", "Meetings");

                            b1.WithOwner()
                                .HasForeignKey("MeetingId");

                            b1.OwnsMany("Mmu.CleanDdd.Meetings.Domain.Areas.Models.AgendaPoint", "Points", b2 =>
                                {
                                    b2.Property<long>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("bigint")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<long>("AgendaId")
                                        .HasColumnType("bigint");

                                    b2.Property<DateTime>("CreatedDate")
                                        .HasColumnType("datetime2");

                                    b2.Property<int>("Index")
                                        .HasColumnType("int");

                                    b2.Property<DateTime>("UpdatedDate")
                                        .HasColumnType("datetime2");

                                    b2.HasKey("Id");

                                    b2.HasIndex("AgendaId");

                                    b2.ToTable("AgendaPoint", "Meetings");

                                    b2.WithOwner()
                                        .HasForeignKey("AgendaId");

                                    b2.OwnsOne("Mmu.CleanDdd.Meetings.Domain.Areas.Models.AgendaPointDescription", "Description", b3 =>
                                        {
                                            b3.Property<long>("AgendaPointId")
                                                .ValueGeneratedOnAdd()
                                                .HasColumnType("bigint")
                                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                            b3.Property<string>("Text")
                                                .IsRequired()
                                                .HasMaxLength(200)
                                                .HasColumnType("nvarchar(200)");

                                            b3.HasKey("AgendaPointId");

                                            b3.ToTable("AgendaPoint", "Meetings");

                                            b3.WithOwner()
                                                .HasForeignKey("AgendaPointId");
                                        });

                                    b2.Navigation("Description");
                                });

                            b1.Navigation("Points");
                        });

                    b.OwnsMany("Mmu.CleanDdd.Meetings.Domain.Areas.Models.Participant", "Participants", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("CreatedDate")
                                .HasColumnType("datetime2");

                            b1.Property<long>("MeetingId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Name")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<DateTime>("UpdatedDate")
                                .HasColumnType("datetime2");

                            b1.HasKey("Id");

                            b1.HasIndex("MeetingId");

                            b1.ToTable("Participant", "Meetings");

                            b1.WithOwner()
                                .HasForeignKey("MeetingId");
                        });

                    b.Navigation("Agenda");

                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
