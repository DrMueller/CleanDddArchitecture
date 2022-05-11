using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanDddSimple.DataAccess.TypeConfigurations.Base;
using Mmu.CleanDddSimple.Domain.Models;

namespace Mmu.CleanDddSimple.DataAccess.TypeConfigurations
{
    public class ParticipantConfig : EntityConfigBase<Participant>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Participant> builder)
        {
            builder.Property(f => f.Name).IsRequired();

            builder.ToTable(nameof(Participant), Schemas.Meetings);
        }
    }
}