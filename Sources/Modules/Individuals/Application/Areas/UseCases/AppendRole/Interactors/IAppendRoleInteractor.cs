using System.Threading.Tasks;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.AppendRole.Dtos;

namespace Mmu.CleanDdd.Individuals.Application.Areas.UseCases.AppendRole.Interactors
{
    public interface IAppendRoleInteractor : IIndividualsModuleInteractor
    {
        Task ExecuteAsync(long individualId, AppendRoleRequestDto dto);
    }
}