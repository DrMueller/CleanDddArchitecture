//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Conventions;
//using Mmu.CleanDdd.CrossCutting.Areas.Settings.Services;
//using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts;
//using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts.Implementation;
//using Mmu.CleanDdd.Shared.Domain.Shell.Areas.TypeConfigurations.ConfigProvisioning;

//namespace Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Factories.Implementation
//{
//    public class AppDbContextFactory : IAppDbContextFactory
//    {
//        private readonly IAppSettingsProvider _appSettingsProvider;
//        private readonly Lazy<DbContextOptions> _lazyOptions;
//        private readonly IEnumerable<ITypeConfigAssemblyProvider> _typeConfigAssemblyProviders;

//        public AppDbContextFactory(
//            IAppSettingsProvider appSettingsProvider,
//            IEnumerable<ITypeConfigAssemblyProvider> typeConfigAssemblyProviders)
//        {
//            _appSettingsProvider = appSettingsProvider;
//            _typeConfigAssemblyProviders = typeConfigAssemblyProviders;
//            _lazyOptions = new Lazy<DbContextOptions>(CreateDbContextOptions);
//        }

//        public IAppDbContext Create()
//        {
//            return new AppDbContext(_lazyOptions.Value);
//        }

//        private DbContextOptions CreateDbContextOptions()
//        {
//            var configuration = SqlServerConventionSetBuilder.Build();
//            var mb = new ModelBuilder(configuration);

//            foreach (var prov in _typeConfigAssemblyProviders)
//            {
//                var assembly = prov.Provide();
//                mb.ApplyConfigurationsFromAssembly(assembly);
//            }

//            mb.FinalizeModel();

//            return new DbContextOptionsBuilder()
//                .UseSqlServer(_appSettingsProvider.Settings.ConnectionString)
//                .UseModel(mb.Model)
//                .Options;
//        }
//    }
//}

