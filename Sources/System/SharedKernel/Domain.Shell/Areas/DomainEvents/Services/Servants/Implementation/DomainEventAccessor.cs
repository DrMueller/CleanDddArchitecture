using System.Collections.Generic;
using System.Linq;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.DomainEvents;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Models;
using Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.DbContexts.Contexts;

namespace Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.DomainEvents.Services.Servants.Implementation
{
    public class DomainEventAccessor : IDomainEventAccessor
    {
        public IReadOnlyCollection<IDomainEvent> GetDomainEvents(IAppDbContext appContext)
        {
            var domainEntities = appContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            return domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();
        }

        public void ClearAllDomainEvents(IAppDbContext appContext)
        {
            var domainEntities = appContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            domainEntities
                .ForEach(entity => entity.Entity.ClearDomainEvents());
        }
    }
}
