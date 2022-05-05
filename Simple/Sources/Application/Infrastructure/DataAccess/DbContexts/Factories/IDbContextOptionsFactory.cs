using Microsoft.EntityFrameworkCore;

namespace Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Factories
{
    public interface IDbContextOptionsFactory
    {
        DbContextOptions CreateForSqlServer(string connectionString);
    }
}