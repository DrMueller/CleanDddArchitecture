using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanDdd.Meetings.Domain.Areas.Models;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.TypeConfigurations;

namespace Mmu.CleanDdd.Meetings.Domain.Shell.Areas.TypeConfigurations
{
    public class MeetingConfig : EntityConfigBase<Meeting>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Meeting> builder)
        {
            builder
                .Property("_name")
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property("_meetingType")
                .HasColumnName("MeetingType")
                .IsRequired();

            builder
                .Property("_description")
                .HasColumnName("Description")
                .HasMaxLength(200)
                .IsRequired();

            builder.OwnsOne(f => f.Agenda, ConfigureAgenda());
            builder.OwnsMany(f => f.Participants, ConfigureParticipant());

            builder.ToTable(nameof(Meeting), Schemas.Meetings);
        }

        private static Action<OwnedNavigationBuilder<Meeting, Agenda>> ConfigureAgenda()
        {
            return builder =>
            {
                builder.WithOwner();

                builder.OwnsMany(f => f.Points, ConfigureAgendaPoint());
                builder.ToTable(nameof(Agenda), Schemas.Meetings);
            };
        }

        private static Action<OwnedNavigationBuilder<Agenda, AgendaPoint>> ConfigureAgendaPoint()
        {
            return builder =>
            {
                builder.WithOwner();
                builder.HasKey(f => f.Id);

                builder.Property("_agendaId")
                    .HasColumnName("AgendaId")
                    .IsRequired();

                builder.Property("_index")
                    .HasColumnName("Index")
                    .IsRequired();

                builder.OwnsOne(f => f.Description, ConfigureAgendaPointDescription());
                builder.ToTable(nameof(AgendaPoint), Schemas.Meetings);
            };
        }

        private static Action<OwnedNavigationBuilder<AgendaPoint, AgendaPointDescription>> ConfigureAgendaPointDescription()
        {
            return builder =>
            {
                builder.WithOwner();

                builder.Property(f => f.Text)
                    .HasMaxLength(200)
                    .IsRequired();

                builder.ToTable(nameof(AgendaPoint), Schemas.Meetings);
            };
        }

        private static Action<OwnedNavigationBuilder<Meeting, Participant>> ConfigureParticipant()
        {
            return builder =>
            {
                builder.WithOwner().HasForeignKey("_meetingId");
                builder.HasKey(f => f.Id);

                builder
                    .Property("_meetingId")
                    .HasColumnName("MeetingId");

                builder
                    .Property("_name")
                    .HasColumnName("Name")
                    .HasMaxLength(100);

                builder.ToTable(nameof(Participant), Schemas.Meetings);
            };
        }
    }
}