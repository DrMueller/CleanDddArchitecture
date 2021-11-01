using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanDdd.Individuals.Domain.Areas.Models;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.TypeConfigurations;

namespace Mmu.CleanDdd.Individuals.Domain.Shell.Areas.TypeConfigurations
{
    public class IndividualConfig : EntityConfigBase<Individual>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Individual> builder)
        {
            builder.Property(f => f.BirthDate).IsRequired();
            builder.Property(f => f.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(f => f.Gender).IsRequired();
            builder.Property(f => f.LastName).HasMaxLength(100).IsRequired();
            builder.ToTable(nameof(Individual), Schemas.Individuals);
        }
    }
}