using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts.Implementation;

namespace Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Factories.Implementation
{
    [UsedImplicitly]
    public class DesignTimeAppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            const string ConnectionString = "server=localhost\\sqlexpress;database=CleanArchitecture;Trusted_Connection=True;Max Pool Size = 500;Pooling = True; MultipleActiveResultSets = True";

            var options = new DbContextOptionsBuilder()
                .UseSqlServer(ConnectionString)
                .Options;

            return new AppDbContext(options);
        }
    }
}