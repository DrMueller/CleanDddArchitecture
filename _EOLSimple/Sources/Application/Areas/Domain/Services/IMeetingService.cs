using System.Threading.Tasks;
using Mmu.CleanDddSimple.Areas.Domain.Models;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Errors;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Types.Eithers;

namespace Mmu.CleanDddSimple.Areas.Domain.Services
{
    public interface IMeetingService
    {
        Task<Either<ServerError, IMeeting>> TryCreatingMeetingAsync(
            string name,
            string description,
            MeetingType type);
    }
}