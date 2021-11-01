using Lamar;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases;

namespace Mmu.CleanDdd.Individuals.Application.Areas.Module.Implementation
{
    public class IndividualsModule : IIndividualsModule
    {
        private readonly IContainer _container;

        public IndividualsModule(IContainer container)
        {
            _container = container;
        }

        public T GetInteractor<T>() where T : IIndividualsModuleInteractor
        {
            return _container.GetInstance<T>();
        }
    }
}