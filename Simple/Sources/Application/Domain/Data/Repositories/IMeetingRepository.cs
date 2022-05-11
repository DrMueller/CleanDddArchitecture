using System.Threading.Tasks;
using Mmu.CleanDddSimple.Domain.Models;

namespace Mmu.CleanDddSimple.Domain.Data.Repositories
{
    public interface IMeetingRepository : IRepository<IMeeting>
    {
        Task<bool> ContainsAnyAsync(string meetingName);
    }
}