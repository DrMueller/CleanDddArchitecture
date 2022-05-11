using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDddSimple.Domain.Data.Querying;
using Mmu.CleanDddSimple.Domain.Models;

namespace Mmu.CleanDddSimple.Application.UseCases.LoadAgendaOverview
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