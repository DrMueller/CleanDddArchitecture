using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDddSimple.Areas.Domain.Models;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.Querying;

namespace Mmu.CleanDddSimple.Areas.Application.UseCases.LoadAgendaOverview
{
    public class AgendaOverviewSpec : IQuerySpecification<Agenda, AgendaOverviewResultDto>
    {
        public const int MaxEntries = 10;

        public Expression<Func<Agenda, AgendaOverviewResultDto>> Selector => a => new AgendaOverviewResultDto
        {
            AgendaPoints = a.Points
                .Select(f => f.Description.Text)
                .OrderBy(f => f)
                .ToList(),
            MeetingId = a.MeetingId,
            AgendaId = a.Id
        };

        public IQueryable<Agenda> Apply(IQueryable<Agenda> qry)
        {
            return qry
                .Include(f => f.Points)
                .Take(MaxEntries);
        }
    }
}