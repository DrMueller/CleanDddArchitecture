using System.Threading.Tasks;
using Mmu.CleanDddSimple.Areas.Domain.Models;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.Repositories;

namespace Mmu.CleanDddSimple.Areas.Domain.Repositories
{
    public interface IMeetingRepository : IRepository<IMeeting>
    {
        Task<bool> ContainsAnyAsync(string meetingName);
    }
}