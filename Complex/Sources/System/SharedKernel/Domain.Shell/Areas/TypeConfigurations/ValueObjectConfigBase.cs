using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Models;

namespace Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.TypeConfigurations
{
    public abstract class ValueObjectConfigBase<T> : IEntityTypeConfiguration<T>
        where T : ValueObject<T>
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            ConfigureValueObject(builder);
        }

        protected abstract void ConfigureValueObject(EntityTypeBuilder<T> builder);
    }
}