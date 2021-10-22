using System.Threading.Tasks;
using Mmu.CleanDdd.Individuals.Domain.Areas.Repositories;
using Mmu.CleanDdd.Shared.Domain.Services.UnitOfWorks;

namespace Mmu.CleanDdd.Individuals.Application.Areas.UseCases.DeleteIndividual.Interactors.Implementation
{
    public class DeleteIndividualInteractor : IDeleteIndividualInteractor
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public DeleteIndividualInteractor(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task ExecuteAsync(long individualId)
        {
            using var uow = _uowFactory.Create();

            var indRepo = uow.GetRepository<IIndividualRepository>();
            await indRepo.DeleteAsync(individualId);

            await uow.SaveAsync();
        }
    }
}