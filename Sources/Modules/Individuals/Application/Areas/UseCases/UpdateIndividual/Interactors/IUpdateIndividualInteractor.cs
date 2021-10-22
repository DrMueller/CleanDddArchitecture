using System.Threading.Tasks;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.UpdateIndividual.Dtos;

namespace Mmu.CleanDdd.Individuals.Application.Areas.UseCases.UpdateIndividual.Interactors
{
    public interface IUpdateIndividualInteractor : IIndividualsModuleInteractor
    {
        Task ExecuteAsync(long individualId, IndividualToUpdateDto dto);
    }
}
