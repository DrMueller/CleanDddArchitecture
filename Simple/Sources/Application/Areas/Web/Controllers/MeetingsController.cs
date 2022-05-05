using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.CleanDddSimple.Areas.Application.UseCases.AddParticipant;
using Mmu.CleanDddSimple.Areas.Application.UseCases.AppendAgendaPoint;
using Mmu.CleanDddSimple.Areas.Application.UseCases.CreateMeeting;
using Mmu.CleanDddSimple.Areas.Application.UseCases.LoadAgendaOverview;
using Mmu.CleanDddSimple.Areas.Application.UseCases.LoadMeeting;
using Mmu.CleanDddSimple.Areas.Web.Dtos;
using Mmu.CleanDddSimple.Infrastructure.Application.Mediation.Services;
using Mmu.CleanDddSimple.Infrastructure.Web.ActionResults;

namespace Mmu.CleanDddSimple.Areas.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingsController : ControllerBase
    {
        private readonly IMediationService _mediator;

        public MeetingsController(IMediationService mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{meetingId:long}/agenda/points")]
        public async Task<IActionResult> AppendAgendaPointAsync([FromRoute] long meetingId, [FromBody] AppendAgendaPointRequestDto dto)
        {
            await _mediator.SendAsync(
                new AppendAgendaPointCommand(
                    meetingId,
                    dto.PointDescription));

            return Ok();
        }

        [HttpPost("{meetingId:long}/participants")]
        public async Task<IActionResult> AppendParticipantAsync([FromRoute] long meetingId, [FromBody] AppendParticipantRequestDto dto)
        {
            var result = await _mediator.SendAsync(
                new AddParticipantCommand(
                    meetingId,
                    dto.ParticipantName));

            return result.ToActionResult();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeetingAsync([FromBody] CreateMeetingRequestDto dto)
        {
            var creationResult = await _mediator.SendAsync(
                new CreateMeetingCommand(
                    dto.Name,
                    dto.Description,
                    dto.MeetingType));

            return creationResult.ToActionResult();
        }

        [HttpGet("{meetingId:long}")]
        public async Task<IActionResult> LoadMeetingAsync([FromRoute] long meetingId)
        {
            var meeting = await _mediator.SendAsync(new LoadMeetingQuery(meetingId));

            return meeting.ToActionResult();
        }

        [HttpGet("agendaoverview")]
        public async Task<IActionResult> LoadOverviewAsync()
        {
            var overview = await _mediator.SendAsync(new LoadAgendaOverviewQuery());

            return Ok(overview);
        }
    }
}