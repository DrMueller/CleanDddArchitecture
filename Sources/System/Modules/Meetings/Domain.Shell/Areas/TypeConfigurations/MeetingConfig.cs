using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanDdd.Meetings.Domain.Areas.Models;
using Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.TypeConfigurations;

namespace Mmu.CleanDdd.Meetings.Domain.Shell.Areas.TypeConfigurations
{
    public class MeetingConfig : EntityConfigBase<Meeting>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Meeting> builder)
        {
            builder
                .Property(f => f.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(f => f.MeetingType)
                .IsRequired();

            builder
                .Property(f => f.Description)
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
                builder.WithOwner().HasForeignKey(f => f.MeetingId);
                builder.HasKey(f => f.Id);

                builder.Property(f => f.MeetingId)
                    .IsRequired();

                builder.OwnsMany(f => f.Points, ConfigureAgendaPoint());
                builder.ToTable(nameof(Agenda), Schemas.Meetings);
            };
        }

        private static Action<OwnedNavigationBuilder<Agenda, AgendaPoint>> ConfigureAgendaPoint()
        {
            return builder =>
            {
                builder.WithOwner().HasForeignKey(f => f.AgendaId);
                builder.HasKey(f => f.Id);

                builder.Property(f => f.AgendaId)
                    .IsRequired();

                builder.Property(f => f.Index)
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
                builder.WithOwner();
                builder.HasKey(f => f.Id);

                builder
                    .Property(f => f.Name)
                    .HasMaxLength(100);

                builder.ToTable(nameof(Participant), Schemas.Meetings);
            };
        }
    }
}