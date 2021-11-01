using Mmu.CleanDdd.Meetings.Domain.Areas.Models;
using Mmu.CleanDdd.Shared.Domain.Areas.Services.Repositories;

namespace Mmu.CleanDdd.Meetings.Domain.Areas.Repositories
{
    public interface IMeetingRepository : IRepository<Meeting>
    {
    }
}