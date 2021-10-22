using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanDdd.Individuals.Domain.Areas.Models;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.TypeConfigurations.Base;

namespace Mmu.CleanDdd.Shared.Domain.Shell.Areas.TypeConfigurations.Roles
{
    public class RoleConfig : EntityConfigBase<Role>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Role> builder)
        {
            builder.Property(f => f.Description).HasMaxLength(100).IsRequired();

            builder.HasOne(role => role.Individual)
                .WithMany(ind => ind.Roles)
                .IsRequired();

            builder.HasOne(role => role.Organisation)
                .WithMany(org => org.Roles)
                .IsRequired();

            builder.ToTable(nameof(Role), Schemas.Individuals);
        }
    }
}