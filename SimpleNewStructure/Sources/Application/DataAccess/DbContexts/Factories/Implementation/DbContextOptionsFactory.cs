using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Mmu.CleanDddSimple.DataAccess.DbContexts.Factories.Implementation
{
    public class DbContextOptionsFactory : IDbContextOptionsFactory
    {
        public DbContextOptions CreateForSqlServer(string connectionString)
        {
            var configuration = SqlServerConventionSetBuilder.Build();
            var mb = new ModelBuilder(configuration);
            mb.ApplyConfigurationsFromAssembly(typeof(AppDbContextFactory).Assembly);

            return new DbContextOptionsBuilder()
                .UseSqlServer(connectionString)
                .UseModel(mb.FinalizeModel())
                .Options;
        }
    }
}