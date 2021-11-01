using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts;

namespace Mmu.CleanDdd.Shared.Domain.Shell.Areas.DomainEvents.Services
{
    public interface IDomainEventDispatcher
    {
        Task DispatchEventsAsync(IAppDbContext dbContext);
    }
}
