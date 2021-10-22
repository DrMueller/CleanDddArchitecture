using System.Threading.Tasks;
using Mmu.CleanDdd.Individuals.Domain.Areas.Models;
using Mmu.CleanDdd.Shared.Domain.DomainServices.Repositories;
using Mmu.CleanDdd.Shared.Domain.Specifications;

namespace Mmu.CleanDdd.Individuals.Domain.Areas.Repositories
{
    public interface IIndividualRepository : IRepository<Individual>
    {
    }
}