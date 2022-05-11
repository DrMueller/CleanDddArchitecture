using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanDddSimple.Areas.Domain.Models;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.TypeConfigurations;

namespace Mmu.CleanDddSimple.Areas.DataAccess.TypeConfigurations
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