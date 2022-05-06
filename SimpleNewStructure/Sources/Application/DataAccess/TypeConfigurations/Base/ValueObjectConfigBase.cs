using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanDddSimple.Domain.Models.Base;

namespace Mmu.CleanDddSimple.DataAccess.TypeConfigurations.Base
{
    public abstract class ValueObjectConfigBase<T> : IEntityTypeConfiguration<T>
        where T : ValueObject
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            ConfigureValueObject(builder);
        }

        protected abstract void ConfigureValueObject(EntityTypeBuilder<T> builder);
    }
}