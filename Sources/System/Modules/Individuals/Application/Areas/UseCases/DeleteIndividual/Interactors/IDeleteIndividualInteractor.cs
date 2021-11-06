using System.Threading.Tasks;

namespace Mmu.CleanDdd.Individuals.Application.Areas.UseCases.DeleteIndividual.Interactors
{
    public interface IDeleteIndividualInteractor : IIndividualsModuleInteractor
    {
        Task ExecuteAsync(long individualId);
    }
}