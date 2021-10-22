using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Mmu.CleanDdd.CrossCutting.Areas.Settings.Services;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts.Implementation;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.TypeConfigurations.Base;

namespace Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Factories.Implementation
{
    public class AppDbContextFactory : IAppDbContextFactory
    {
        private readonly IAppSettingsProvider _appSettingsProvider;
        private readonly Lazy<DbContextOptions> _lazyOptions;

        public AppDbContextFactory(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
            _lazyOptions = new Lazy<DbContextOptions>(CreateDbContextOptions);
        }

        public IAppDbContext Create()
        {
            return new AppDbContext(_lazyOptions.Value);
        }

        private DbContextOptions CreateDbContextOptions()
        {
            var configuration = SqlServerConventionSetBuilder.Build();
            var mb = new ModelBuilder(configuration);
            var entityConfigAssembly = typeof(EntityConfigBase<>).Assembly;
            mb.ApplyConfigurationsFromAssembly(entityConfigAssembly);
            mb.FinalizeModel();

            return new DbContextOptionsBuilder()
                .UseSqlServer(_appSettingsProvider.Settings.ConnectionString)
                .UseModel(mb.Model)
                .Options;
        }
    }
}