using Lamar;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases;

namespace Mmu.CleanDdd.Individuals.Application.Areas.Module.Implementation
{
    public class IndividualsModule : IIndividualsModule
    {
        private readonly IContainer container;

        public IndividualsModule(IContainer container)
        {
            this.container = container;
        }

        public T GetInteractor<T>() where T : IIndividualsModuleInteractor
        {
            return container.GetInstance<T>();
        }
    }
}