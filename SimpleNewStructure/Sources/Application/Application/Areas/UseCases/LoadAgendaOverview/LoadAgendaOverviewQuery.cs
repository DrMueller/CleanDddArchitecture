using System.Collections.Generic;
using Mmu.CleanDddSimple.Application.Areas.Mediation.Models;

namespace Mmu.CleanDddSimple.Application.Areas.UseCases.LoadAgendaOverview
{
    public class LoadAgendaOverviewQuery : IQuery<IReadOnlyCollection<AgendaOverviewResultDto>>
    {
    }
}