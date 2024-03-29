﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDddSimple.Areas.Domain.Models;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.Repositories.Base;

namespace Mmu.CleanDddSimple.Areas.Domain.Repositories.Implementation
{
    public class MeetingRepository : RepositoryBase<IMeeting, Meeting>, IMeetingRepository
    {
        public async Task<bool> ContainsAnyAsync(string meetingName)
        {
            return await Query.AnyAsync(f => f.Name == meetingName);
        }

        protected override IQueryable<Meeting> InitializeIncludes(IQueryable<Meeting> query)
        {
            return query.Include(f => f.Agenda)
                .ThenInclude(f => f.Points)
                .Include(f => f.Participants);
        }
    }
}