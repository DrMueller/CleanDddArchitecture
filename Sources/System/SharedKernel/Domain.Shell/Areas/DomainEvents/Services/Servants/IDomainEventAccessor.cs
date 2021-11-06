using System.Collections.Generic;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.DomainEvents;
using Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.DbContexts.Contexts;

namespace Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.DomainEvents.Services.Servants
{
    public interface IDomainEventAccessor
    {
        void ClearAllDomainEvents(IAppDbContext appContext);

        IReadOnlyCollection<IDomainEvent> GetDomainEvents(IAppDbContext appContext);
    }
}