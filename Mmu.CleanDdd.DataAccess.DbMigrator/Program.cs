using System;
using Lamar;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Mmu.CleanDdd.CrossCutting.Areas.Settings.Config.Services.Implementation;
using Mmu.CleanDdd.CrossCutting.Areas.Settings.Models;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts.Implementation;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Factories;

namespace Mmu.CleanDdd.DataAccess.DbMigrator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = CreateContainer();

            var appDbContextFactory = container.GetInstance<IAppDbContextFactory>();
            var appDbContext = (AppDbContext)appDbContextFactory.Create();
            appDbContext.Database.Migrate();
        }

        private static IContainer CreateContainer()
        {
            return new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssembliesFromApplicationBaseDirectory();
                    scanner.LookForRegistries();
                });
            });
        }
    }
}