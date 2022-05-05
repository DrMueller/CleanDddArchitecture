using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Collections;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.Repositories;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.UnitOfWorks;
using Mmu.CleanDddSimple.Infrastructure.Domain.ModelAbstractions;

namespace Mmu.CleanDddSimple.Testing.Common.Areas.DataAccess.AggregatePersisting.Implementation
{
    [UsedImplicitly]
    public class AggregatePersister : IAggregatePersister
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public AggregatePersister(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task PersistAsync<T>(params T[] aggregates) where T : IAggregateRoot
        {
            using var uow = _uowFactory.Create();

            var repo = uow.GetRepository<IRepository<T>>();
            await aggregates.ForEachAsync(async ag => await repo.InsertAsync(ag));

            await uow.SaveAsync();
        }
    }
}