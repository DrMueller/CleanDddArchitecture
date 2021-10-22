using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanDdd.Individuals.Domain.Areas.Models;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.TypeConfigurations.Base;

namespace Mmu.CleanDdd.Shared.Domain.Shell.Areas.TypeConfigurations.Organisations
{
    public class OrganisationConfig : EntityConfigBase<Organisation>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Organisation> builder)
        {
            builder.Property(f => f.Name).HasMaxLength(100).IsRequired();
            builder.ToTable(nameof(Organisation), Schemas.Individuals);
        }
    }
}