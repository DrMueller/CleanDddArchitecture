using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.CleanDdd.Meetings.Application.Areas.Module;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Agenda.AddAgendaPoint.Dtos;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Agenda.AddAgendaPoint.Interactors;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.CreateMeeting.Dtos;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.CreateMeeting.Interactors;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.LoadMeetingsOverview.Dtos;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.LoadMeetingsOverview.Interactors;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Participants.AddParticipant.Dtos;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Participants.AddParticipant.Interactors;

namespace Mmu.CleanDdd.WebApi.Areas.Modules.Meetings
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingsController : ControllerBase
    {
        private readonly IMeetingsModule _meetingsModule;

        public MeetingsController(IMeetingsModule meetingsModule)
        {
            _meetingsModule = meetingsModule;
        }

        [HttpPost("{meetingId:long}/agenda/point")]
        public async Task<IActionResult> CreateAgendaPointAsync(
            [FromRoute] long meetingId,
            [FromBody] CreateAgendaPointRequestDto dto)
        {
            await
                _meetingsModule
                    .GetInteractor<IAddAgendaPointInteractor>()
                    .ExecuteAsync(meetingId, dto);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeetingAsync([FromBody] CreateMeetingRequestDto dto)
        {
            var meetingId = await
                _meetingsModule
                    .GetInteractor<ICreateMeetingInteractor>()
                    .ExecuteAsync(dto);

            return Ok(meetingId);
        }

        [HttpPost("{meetingId:long}/participants")]
        public async Task<IActionResult> CreateParticipantAsync(
            [FromRoute] long meetingId,
            [FromBody] AddParticipantRequestDto dto)
        {
            await
                _meetingsModule
                    .GetInteractor<IAddParticipantInteractor>()
                    .ExecuteAsync(meetingId, dto);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<MeetingOverviewResponseDto>>> GetOverviewAsync()
        {
            var dtos = await _meetingsModule
                .GetInteractor<ILoadMeetingsOverviewInteractor>()
                .ExecuteAsync();

            return Ok(dtos);
        }
    }
}