using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Mmu.CleanDdd.CrossCutting.Areas.Settings.Provisioning.Services;
using Mmu.CleanDdd.DataAccess.Areas.DbContexts.Contexts.Implementation;
using Mmu.CleanDdd.Individuals.Domain.Shell.Areas.TypeConfigurations;
using Mmu.CleanDdd.Meetings.Domain.Shell.Areas.TypeConfigurations;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Factories;

namespace Mmu.CleanDdd.DataAccess.Areas.DbContexts.Factories.Implementation
{
    public class AppDbContextFactory : IAppDbContextFactory
    {
        private readonly IAppSettingsProvider _appSettingsProvider;
        private readonly Lazy<DbContextOptions> _lazyOptions;

        public AppDbContextFactory(
            IAppSettingsProvider appSettingsProvider)
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
            mb.ApplyConfigurationsFromAssembly(typeof(IndividualConfig).Assembly);
            mb.ApplyConfigurationsFromAssembly(typeof(MeetingConfig).Assembly);

            mb.FinalizeModel();

            return new DbContextOptionsBuilder()
                .UseSqlServer(_appSettingsProvider.Settings.ConnectionString)
                .UseModel(mb.Model)
                .Options;
        }
    }
}