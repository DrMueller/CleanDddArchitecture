using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Models;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Specifications;

namespace Mmu.CleanDdd.SharedKernel.Domain.Areas.Querying
{
    public interface IQueryService
    {
        Task<IReadOnlyCollection<TResult>> QueryAsync<TAg, TResult>(ISpecification<TAg, TResult> spec)
            where TAg : AggregateRoot;

        Task<IReadOnlyCollection<TAg>> QueryAsync<TAg>(ISpecification<TAg> spec)
            where TAg : AggregateRoot;
    }
}