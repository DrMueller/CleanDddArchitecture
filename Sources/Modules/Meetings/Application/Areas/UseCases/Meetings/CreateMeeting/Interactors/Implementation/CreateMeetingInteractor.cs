using System.Threading.Tasks;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.CreateMeeting.Dtos;
using Mmu.CleanDdd.Meetings.Domain.Areas.Factories;
using Mmu.CleanDdd.Meetings.Domain.Areas.Models;
using Mmu.CleanDdd.Meetings.Domain.Areas.Repositories;
using Mmu.CleanDdd.Shared.Domain.Areas.Services.UnitOfWorks;

namespace Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.CreateMeeting.Interactors.Implementation
{
    public class CreateMeetingInteractor : ICreateMeetingInteractor
    {
        private readonly IMeetingFactory _meetingFactory;
        private readonly IUnitOfWorkFactory _uowFactory;

        public CreateMeetingInteractor(
            IMeetingFactory meetingFactory,
            IUnitOfWorkFactory uowFactory)
        {
            _meetingFactory = meetingFactory;
            _uowFactory = uowFactory;
        }

        public async Task<long> ExecuteAsync(CreateMeetingRequestDto dto)
        {
            using (var uow = _uowFactory.Create())
            {
                var meetingRepo = uow.GetRepository<IMeetingRepository>();
                var meetingType = (MeetingType)dto.MeetingType;
                var meeting = _meetingFactory.Create(dto.Name, dto.Description, meetingType);

                meeting.CreateAgenda();
                await meetingRepo.UpsertAsync(meeting);
                await uow.SaveAsync();

                return meeting.Id;
            }
        }
    }
}