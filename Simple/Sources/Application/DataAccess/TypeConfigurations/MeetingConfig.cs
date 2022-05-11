using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanDddSimple.DataAccess.TypeConfigurations.Base;
using Mmu.CleanDddSimple.Domain.Models;

namespace Mmu.CleanDddSimple.DataAccess.TypeConfigurations
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

            builder
                .HasMany(f => f.Participants)
                .WithOne()
                .IsRequired();

            builder.HasOne(f => f.Agenda)
                .WithOne()
                .HasForeignKey<Agenda>(f => f.MeetingId)
                .IsRequired();

            builder.ToTable(nameof(Meeting), Schemas.Meetings);
        }
    }
}