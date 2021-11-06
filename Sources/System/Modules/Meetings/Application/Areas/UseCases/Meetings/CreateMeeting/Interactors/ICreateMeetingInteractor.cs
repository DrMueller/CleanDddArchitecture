using System.Threading.Tasks;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.CreateMeeting.Dtos;

namespace Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.CreateMeeting.Interactors
{
    public interface ICreateMeetingInteractor : IMeetingsModuleInteractor
    {
        Task<long> ExecuteAsync(CreateMeetingRequestDto dto);
    }
}