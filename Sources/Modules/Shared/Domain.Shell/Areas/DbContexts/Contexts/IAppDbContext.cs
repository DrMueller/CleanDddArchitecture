using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts
{
    public interface IAppDbContext : IDisposable
    {
        ChangeTracker ChangeTrackerr { get; }

        Task<int> SaveChangesAsync(CancellationToken token = default);

        [SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Same name as the one on the DbContext needed")]
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}