using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts.Implementation
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public ChangeTracker ChangeTrackerr => base.ChangeTracker;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.ConfigureWarnings(warnings => warnings.Throw());
        }
    }
}