using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.CleanDdd.Individuals.Domain.Areas.Models;
using Mmu.CleanDdd.Individuals.Domain.Areas.Repositories;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.Repositories.Base.Implementation;

namespace Mmu.CleanDdd.Individuals.Domain.Shell.Areas.Repositories
{
    public class IndividualRepository : RepositoryBase<Individual>, IIndividualRepository
    {
    }
}
