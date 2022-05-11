using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.CleanDddSimple.Infrastructure.Domain.ModelAbstractions;

namespace Mmu.CleanDddSimple.Infrastructure.DataAccess.Querying
{
    public interface IQueryService
    {
        Task<IReadOnlyCollection<TResult>> QueryAsync<T, TResult>(IQuerySpecification<T, TResult> spec)
            where T : Entity;

        Task<IReadOnlyCollection<T>> QueryAsync<T>(IQuerySpecification<T> spec)
            where T : Entity;
    }
}