using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanDdd.Shared.Domain.Areas.Models;

namespace Mmu.CleanDdd.Shared.Domain.Shell.Areas.TypeConfigurations
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