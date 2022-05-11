using System.Threading.Tasks;
using Mmu.CleanDddSimple.Domain.Models.Base;

namespace Mmu.CleanDddSimple.Testing.Common.Areas.DataAccess.AggregatePersisting
{
    public interface IAggregatePersister
    {
        Task PersistAsync<T>(params T[] aggregates)
            where T : IAggregateRoot;
    }
}