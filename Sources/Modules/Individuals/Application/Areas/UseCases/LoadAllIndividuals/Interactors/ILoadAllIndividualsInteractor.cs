using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadAllIndividuals.Dtos;

namespace Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadAllIndividuals.Interactors
{
    public interface ILoadAllIndividualsInteractor : IIndividualsModuleInteractor
    {
        Task<IReadOnlyCollection<IndividualResultDto>> ExecuteAsync();
    }
}