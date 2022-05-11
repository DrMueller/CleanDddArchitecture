using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanDddSimple.DataAccess.TypeConfigurations.Base;
using Mmu.CleanDddSimple.Domain.Models;

namespace Mmu.CleanDddSimple.DataAccess.TypeConfigurations
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