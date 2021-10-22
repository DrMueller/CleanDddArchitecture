using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDdd.Individuals.Domain.Areas.Models;
using Mmu.CleanDdd.Shared.Domain.Specifications;

namespace Mmu.CleanDdd.Individuals.Application.Areas.UseCases.AppendRole.Specs
{
    public class LoadIndividualWithRolesSpec : ISpecification<Individual>
    {
        private readonly long _individualId;

        public LoadIndividualWithRolesSpec(long individualId)
        {
            _individualId = individualId;
        }

        public IQueryable<Individual> Apply(IQueryable<Individual> qry)
        {
            return qry
                .Include(f => f.Roles)
                .Where(f => f.Id == _individualId);
        }
    }
}