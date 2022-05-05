using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Types.Maybes;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.Repositories;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.UnitOfWorks;
using Mmu.CleanDddSimple.Infrastructure.Domain.ModelAbstractions;

namespace Mmu.CleanDddSimple.Testing.Common.Areas.DataAccess.AggregateLoading.Implementation
{
    [UsedImplicitly]
    public class AggregateLoader : IAggregateLoader
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public AggregateLoader(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task<T> LoadAsync<T>(long id) where T : IAggregateRoot
        {
            using var uow = _uowFactory.Create();
            var repo = uow.GetRepository<IRepository<T>>();
            var aggregateMaybe = await repo.LoadSingleAsync(id);

            return aggregateMaybe.ReduceThrow();
        }
    }
}