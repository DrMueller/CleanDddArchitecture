using System.Threading.Tasks;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.CreateIndividual.Dtos;

namespace Mmu.CleanDdd.Individuals.Application.Areas.UseCases.CreateIndividual.Interactors
{
    public interface ICreateIndividualInteractor : IIndividualsModuleInteractor
    {
        Task<CreateIndividualResultDto> ExecuteAsync(CreateIndividualRequestDto dto);
    }
}