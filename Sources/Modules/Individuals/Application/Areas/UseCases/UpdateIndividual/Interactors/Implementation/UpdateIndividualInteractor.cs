using System.Threading.Tasks;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.UpdateIndividual.Dtos;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.UpdateIndividual.Specs;
using Mmu.CleanDdd.Individuals.Domain.Areas.Repositories;
using Mmu.CleanDdd.Shared.Domain.Areas.Services.UnitOfWorks;

namespace Mmu.CleanDdd.Individuals.Application.Areas.UseCases.UpdateIndividual.Interactors.Implementation
{
    public class UpdateIndividualInteractor : IUpdateIndividualInteractor
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public UpdateIndividualInteractor(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task ExecuteAsync(long individualId, IndividualToUpdateDto dto)
        {
            using var uow = _uowFactory.Create();
            var indRepo = uow.GetRepository<IIndividualRepository>();

            var ind = await indRepo.LoadAsync(new LoadIndividualByIdSpec(individualId));
            ind.FirstName = dto.NewFirstName;

            await uow.SaveAsync();
        }
    }
}