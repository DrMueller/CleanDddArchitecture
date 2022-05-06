using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanDddSimple.DataAccess.TypeConfigurations.Base;
using Mmu.CleanDddSimple.Domain.Models;

namespace Mmu.CleanDddSimple.DataAccess.TypeConfigurations
{
    public class AgendaPointConfig : EntityConfigBase<AgendaPoint>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<AgendaPoint> builder)
        {
            builder.Property(f => f.Index).IsRequired();

            builder.OwnsOne(f => f.Description, ConfigureAgendaPointDescription());

            builder.ToTable(nameof(AgendaPoint), Schemas.Meetings);
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
    }
}