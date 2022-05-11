using System.Threading.Tasks;
using Mmu.CleanDddSimple.CrossCutting.Errors;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Eithers;
using Mmu.CleanDddSimple.Domain.Models;

namespace Mmu.CleanDddSimple.Domain.Services
{
    public interface IMeetingService
    {
        Task<Either<ServerError, IMeeting>> TryCreatingMeetingAsync(
            string name,
            string description,
            MeetingType type);
    }
}