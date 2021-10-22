using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDdd.Individuals.Domain.Areas.Models;
using Mmu.CleanDdd.Shared.Domain.Specifications;

namespace Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadFirstIndividualWithRoles.Specs
{
    public class LoadIndividualsWithRolesSpec : ISpecification<Individual>
    {
        public IQueryable<Individual> Apply(IQueryable<Individual> qry)
        {
            return qry
                .Include(f => f.Roles)
                .Where(f => f.Roles.Any());
        }
    }
}