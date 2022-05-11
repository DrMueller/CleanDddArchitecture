using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Contexts;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Contexts.Implementation;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Factories;

namespace Mmu.CleanDddSimple.Testing.Common.Areas.DataAccess.DbContexts.Factories
{
    [UsedImplicitly]
    public class InMemoryAppDbContextFactory : IAppDbContextFactory
    {
        private string _databaseName = null!;

        public IAppDbContext Create()
        {
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(_databaseName)
                .Options;

            var context = new AppDbContext(options);
            context.Database.EnsureCreated(); // This makes sure the dataseeding of the Code-Entities (via `HasData`) is applied to the tests

            return context;
        }

        public void InitializeName()
        {
            _databaseName = Guid.NewGuid().ToString();
        }
    }
}