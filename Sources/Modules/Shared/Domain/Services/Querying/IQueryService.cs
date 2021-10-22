using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.CleanDdd.Shared.Domain.Models;
using Mmu.CleanDdd.Shared.Domain.Specifications;

namespace Mmu.CleanDdd.Shared.Domain.Services.Querying
{
    public interface IQueryService
    {
        Task<IReadOnlyCollection<TResult>> QueryAsync<TAg, TResult>(ISpecification<TAg, TResult> spec)
            where TAg : AggregateRoot;

        Task<IReadOnlyCollection<TAg>> QueryAsync<TAg>(ISpecification<TAg> spec)
            where TAg : AggregateRoot;
    }
}