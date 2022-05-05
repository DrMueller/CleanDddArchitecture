using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanDddSimple.Areas.Domain.Models;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.TypeConfigurations;

namespace Mmu.CleanDddSimple.Areas.DataAccess.TypeConfigurations
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