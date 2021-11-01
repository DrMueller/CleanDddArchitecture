using System.Threading.Tasks;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Agenda.AddAgendaPoint.Dtos;

namespace Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Agenda.AddAgendaPoint.Interactors
{
    public interface IAddAgendaPointInteractor : IMeetingsModuleInteractor
    {
        Task ExecuteAsync(long meetingId, CreateAgendaPointRequestDto dto);
    }
}