using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.CleanDdd.Shared.Domain.Areas.DomainEvents;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts;

namespace Mmu.CleanDdd.Shared.Domain.Shell.Areas.DomainEvents.Services.Servants
{
    public interface IDomainEventAccessor
    {
        void ClearAllDomainEvents(IAppDbContext appContext);

        IReadOnlyCollection<IDomainEvent> GetDomainEvents(IAppDbContext appContext);
    }
}
