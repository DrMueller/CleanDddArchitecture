using System.Threading.Tasks;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadFirstIndividualWithRoles.Dtos;

namespace Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadFirstIndividualWithRoles.Interactors
{
    public interface ILoadFirstIndividualWithRolesInteractor : IIndividualsModuleInteractor
    {
        Task<IndividualWithRolesDto> ExecuteAsync();
    }
}