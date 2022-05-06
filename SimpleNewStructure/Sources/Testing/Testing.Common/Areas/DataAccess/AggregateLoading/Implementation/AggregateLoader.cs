using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Maybes;
using Mmu.CleanDddSimple.DataAccess.UnitOfWorks;
using Mmu.CleanDddSimple.Domain.Data.Repositories;
using Mmu.CleanDddSimple.Domain.Data.UnitOfWorks;
using Mmu.CleanDddSimple.Domain.Models.Base;

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