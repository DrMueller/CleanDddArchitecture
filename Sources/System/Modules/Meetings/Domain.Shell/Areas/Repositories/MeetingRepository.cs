using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDdd.Meetings.Domain.Areas.Models;
using Mmu.CleanDdd.Meetings.Domain.Areas.Repositories;
using Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.Repositories.Base;

namespace Mmu.CleanDdd.Meetings.Domain.Shell.Areas.Repositories
{
    public class MeetingRepository : RepositoryBase<Meeting>, IMeetingRepository
    {
        protected override IQueryable<Meeting> InitializeIncludes(IQueryable<Meeting> query)
        {
            return query.Include(f => f.Agenda)
                .ThenInclude(f => f.Points)
                .Include(f => f.Participants);
        }
    }
}