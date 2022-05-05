using System.Threading.Tasks;
using Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.DbContexts.Contexts;

namespace Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.DomainEvents.Services
{
    public interface IDomainEventDispatcher
    {
        Task DispatchEventsAsync(IAppDbContext dbContext);
    }
}