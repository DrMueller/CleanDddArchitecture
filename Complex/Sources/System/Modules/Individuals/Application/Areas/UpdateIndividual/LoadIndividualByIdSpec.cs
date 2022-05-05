using System.Linq;
using Mmu.CleanDdd.Individuals.Domain.Areas.Models;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Specifications;

namespace Mmu.CleanDdd.Individuals.Application.Areas.UpdateIndividual
{
    public class LoadIndividualByIdSpec : ISpecification<Individual>
    {
        private readonly long _individualId;

        public LoadIndividualByIdSpec(long individualId)
        {
            _individualId = individualId;
        }

        public IQueryable<Individual> Apply(IQueryable<Individual> qry)
        {
            return qry.Where(ind => ind.Id == _individualId);
        }
    }
}