using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.LoadMeetingsOverview.Dtos;
using Mmu.CleanDdd.Meetings.Domain.Areas.Models;
using Mmu.CleanDdd.Shared.Domain.Areas.Specifications;

namespace Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.LoadMeetingsOverview.Specs
{
    public class LoadMeetingsOverviewSpec : ISpecification<Meeting, MeetingOverviewResponseDto>
    {
        public Expression<Func<Meeting, MeetingOverviewResponseDto>> Selector => f => new MeetingOverviewResponseDto
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
            return qry
                .Include(f => f.Agenda)
                .ThenInclude(f => f.Points);
        }
    }
}