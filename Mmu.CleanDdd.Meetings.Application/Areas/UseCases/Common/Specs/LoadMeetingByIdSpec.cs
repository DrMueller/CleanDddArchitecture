﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDdd.Meetings.Domain.Areas.Models;
using Mmu.CleanDdd.Shared.Domain.Areas.Specifications;

namespace Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Agenda.AddAgendaPoint.Specs
{
    public class LoadMeetingByIdSpec : ISpecification<Meeting>
    {
        private readonly long _meetingId;

        public LoadMeetingByIdSpec(long meetingId)
        {
            _meetingId = meetingId;
        }

        public IQueryable<Meeting> Apply(IQueryable<Meeting> qry)
        {
            return qry
                .Include(f => f.Agenda)
                .ThenInclude(f => f.Points)
                .Include(f => f.Participants)
                .Where(f => f.Id == _meetingId);
        }
    }
}