﻿using System;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Services.Settings.Provisioning.Services;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Contexts;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Contexts.Implementation;

namespace Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Factories.Implementation
{
    public class AppDbContextFactory : IAppDbContextFactory
    {
        private readonly Lazy<DbContextOptions> _lazyOptions;

        public AppDbContextFactory(
            IDbContextOptionsFactory optionsFactory,
            IAppSettingsProvider appSettingsProvider)
        {
            _lazyOptions = new Lazy<DbContextOptions>(
                () => optionsFactory.CreateForSqlServer(
                    appSettingsProvider.Settings.ConnectionString));
        }

        public IAppDbContext Create()
        {
            return new AppDbContext(_lazyOptions.Value);
        }
    }
}