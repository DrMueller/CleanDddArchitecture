using System.Collections.Generic;
using Mmu.CleanDdd.SharedKernel.Application.Areas.Mediation.Models;

namespace Mmu.CleanDdd.Individuals.Application.Areas.LoadAllIndividuals
{
    public class LoadAllIndividualsQuery : IQuery<IReadOnlyCollection<IndividualResultDto>>
    {
    }
}