using Mmu.CleanDdd.Individuals.Application.Areas.UseCases;

namespace Mmu.CleanDdd.Individuals.Application.Areas.Module
{
    public interface IIndividualsModule
    {
        T GetInteractor<T>()
            where T : IIndividualsModuleInteractor;
    }
}