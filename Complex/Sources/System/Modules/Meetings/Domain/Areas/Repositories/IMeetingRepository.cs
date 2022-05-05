using Mmu.CleanDdd.Meetings.Domain.Areas.Models;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Repositories;

namespace Mmu.CleanDdd.Meetings.Domain.Areas.Repositories
{
    public interface IMeetingRepository : IRepository<Meeting>
    {
    }
}