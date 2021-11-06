using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Models;

namespace Mmu.CleanDdd.SharedKernel.Domain.Areas.Repositories
{
    [SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Marker interface for easier generic handling")]
    public interface IRepository
    {
    }

    public interface IRepository<TAg> : IRepository
        where TAg : AggregateRoot
    {
        Task DeleteAsync(long id);

        Task<TAg> LoadAsync(long id);

        Task UpsertAsync(TAg entity);
    }
}