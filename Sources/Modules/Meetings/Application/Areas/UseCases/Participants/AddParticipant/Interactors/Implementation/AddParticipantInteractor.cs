﻿using System.Threading.Tasks;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Common.Specs;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Participants.AddParticipant.Dtos;
using Mmu.CleanDdd.Meetings.Domain.Areas.Repositories;
using Mmu.CleanDdd.Shared.Domain.Areas.Services.UnitOfWorks;

namespace Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Participants.AddParticipant.Interactors.Implementation
{
    public class AddParticipantInteractor : IAddParticipantInteractor
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public AddParticipantInteractor(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task ExecuteAsync(long meetingId, AddParticipantRequestDto dto)
        {
            using (var uow = _uowFactory.Create())
            {
                var meetingRepo = uow.GetRepository<IMeetingRepository>();
                var meeting = await meetingRepo.LoadAsync(new LoadMeetingByIdSpec(meetingId));

                meeting.AddParticipant(dto.ParticipantName);

                await uow.SaveAsync();
            }
        }
    }
}