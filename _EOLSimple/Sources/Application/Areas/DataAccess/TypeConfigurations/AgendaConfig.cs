using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanDddSimple.Areas.Domain.Models;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.TypeConfigurations;

namespace Mmu.CleanDddSimple.Areas.DataAccess.TypeConfigurations
{
    public class AgendaConfig : EntityConfigBase<Agenda>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Agenda> builder)
        {
            builder
                .HasMany(f => f.Points)
                .WithOne();

            builder
                .HasMany(f => f.Points)
                .WithOne()
                .IsRequired();

            builder.ToTable(nameof(Agenda), Schemas.Meetings);
        }
    }
}