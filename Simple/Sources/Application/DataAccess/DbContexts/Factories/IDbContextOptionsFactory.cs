using Microsoft.EntityFrameworkCore;

namespace Mmu.CleanDddSimple.DataAccess.DbContexts.Factories
{
    public interface IDbContextOptionsFactory
    {
        DbContextOptions CreateForSqlServer(string connectionString);
    }
}