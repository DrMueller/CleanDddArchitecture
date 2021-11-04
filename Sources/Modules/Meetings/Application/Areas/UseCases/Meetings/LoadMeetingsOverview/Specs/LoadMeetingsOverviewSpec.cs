using System;
using System.Linq;
using System.Linq.Expressions;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.LoadMeetingsOverview.Dtos;
using Mmu.CleanDdd.Meetings.Domain.Areas.Models;
using Mmu.CleanDdd.Shared.Domain.Areas.Specifications;

namespace Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.LoadMeetingsOverview.Specs
{
    public class LoadMeetingsOverviewSpec : ISpecification<Meeting, MeetingOverviewDto>
    {
        public Expression<Func<Meeting, MeetingOverviewDto>> Selector => f => new MeetingOverviewDto
        {
            MeetingId = f.Id,
            Name = f.Name,
            Type = f.MeetingType.ToString(),
            Agenda = new AgendaDto
            {
                Points = f.Agenda.Points.Select(
                    ap => new AgendaPointDto
                    {
                        Description = ap.Description.Text
                    })
            },
            Participants = f.Participants.Select(
                p => new ParticipantDto
                {
                    ParticipantName = p.Name
                })
        };

        public IQueryable<Meeting> Apply(IQueryable<Meeting> qry)
        {
            return qry.OrderByDescending(f => f.CreatedDate);
        }
    }
}