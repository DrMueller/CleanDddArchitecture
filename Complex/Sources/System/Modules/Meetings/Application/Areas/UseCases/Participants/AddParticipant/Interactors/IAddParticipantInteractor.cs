using System.Threading.Tasks;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Participants.AddParticipant.Dtos;

namespace Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Participants.AddParticipant.Interactors
{
    public interface IAddParticipantInteractor : IMeetingsModuleInteractor
    {
        Task ExecuteAsync(long meetingId, AddParticipantRequestDto dto);
    }
}