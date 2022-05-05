using System.Threading.Tasks;
using Mmu.CleanDddSimple.Infrastructure.Domain.ModelAbstractions;

namespace Mmu.CleanDddSimple.Testing.Common.Areas.DataAccess.AggregateLoading
{
    public interface IAggregateLoader
    {
        Task<T> LoadAsync<T>(long id)
            where T : IAggregateRoot;
    }
}