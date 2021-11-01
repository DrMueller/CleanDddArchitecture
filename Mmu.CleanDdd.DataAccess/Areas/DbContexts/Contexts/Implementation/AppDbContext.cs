﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts;

namespace Mmu.CleanDdd.DataAccess.Areas.DbContexts.Contexts.Implementation
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        private static readonly LoggerFactory MyLoggerFactory =
            new(
                new[]
                {
                    new DebugLoggerProvider()
                });

        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);

            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.ConfigureWarnings(warnings => warnings.Throw());
        }
    }
}