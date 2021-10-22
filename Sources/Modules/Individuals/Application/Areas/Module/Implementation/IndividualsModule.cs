using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return this.container.GetInstance<T>();
        }
    }
}
