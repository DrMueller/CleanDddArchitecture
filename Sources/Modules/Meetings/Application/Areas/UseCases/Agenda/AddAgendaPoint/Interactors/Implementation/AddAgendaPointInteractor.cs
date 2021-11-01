using System.Threading.Tasks;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Agenda.AddAgendaPoint.Dtos;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Common.Specs;
using Mmu.CleanDdd.Meetings.Domain.Areas.Repositories;
using Mmu.CleanDdd.Shared.Domain.Areas.Services.UnitOfWorks;

namespace Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Agenda.AddAgendaPoint.Interactors.Implementation
{
    public class AddAgendaPointInteractor : IAddAgendaPointInteractor
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public AddAgendaPointInteractor(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task ExecuteAsync(long meetingId, CreateAgendaPointRequestDto dto)
        {
            using var uow = _uowFactory.Create();

            var meetingRepo = uow.GetRepository<IMeetingRepository>();
            var meeting = await meetingRepo.LoadAsync(new LoadMeetingByIdSpec(meetingId));

            meeting.Agenda.AddAgendaPoint(dto.Description);
            await uow.SaveAsync();
        }
    }
}