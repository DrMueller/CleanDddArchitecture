using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Mmu.CleanDdd.Shared.Domain.DomainModels;
using Mmu.CleanDdd.Shared.Domain.Specifications;

namespace Mmu.CleanDdd.Shared.Domain.DomainServices.Repositories
{
    [SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Marker interface for easier generic handling")]
    public interface IRepository
    {
    }

    public interface IRepository<TAg> : IRepository
        where TAg : AggregateRoot
    {
        Task DeleteAsync(long id);

        Task<IReadOnlyCollection<TAg>> LoadAllAsync(ISpecification<TAg> spec);

        Task<TAg> LoadAsync(ISpecification<TAg> spec);

        Task UpsertAsync(TAg entity);
    }
}