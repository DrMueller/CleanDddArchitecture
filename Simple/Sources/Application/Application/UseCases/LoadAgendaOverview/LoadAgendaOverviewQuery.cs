using System.Collections.Generic;
using Mmu.CleanDddSimple.Application.Mediation.Models;

namespace Mmu.CleanDddSimple.Application.UseCases.LoadAgendaOverview
{
    public class LoadAgendaOverviewQuery : IQuery<IReadOnlyCollection<AgendaOverviewResultDto>>
    {
    }
}