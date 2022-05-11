using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mmu.CleanDddSimple.DataAccess.DbContexts.Contexts
{
    public interface IAppDbContext : IDisposable
    {
        ChangeTracker ChangeTracker { get; }

        [SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Same name as the one on the DbContext needed")]
        IDbSetProxy<TEntity> DbSet<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}