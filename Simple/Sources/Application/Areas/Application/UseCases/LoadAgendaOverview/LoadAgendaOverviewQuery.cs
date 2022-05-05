using System.Collections.Generic;
using Mmu.CleanDddSimple.Infrastructure.Application.Mediation.Models;

namespace Mmu.CleanDddSimple.Areas.Application.UseCases.LoadAgendaOverview
{
    public class LoadAgendaOverviewQuery : IQuery<IReadOnlyCollection<AgendaOverviewResultDto>>
    {
    }
}