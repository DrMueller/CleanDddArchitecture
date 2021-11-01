using Mmu.CleanDdd.Meetings.Domain.Areas.Models;
using Mmu.CleanDdd.Meetings.Domain.Areas.Repositories;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.Repositories.Base;

namespace Mmu.CleanDdd.Meetings.Domain.Shell.Areas.Repositories
{
    public class MeetingRepository : RepositoryBase<Meeting>, IMeetingRepository
    {
    }
}