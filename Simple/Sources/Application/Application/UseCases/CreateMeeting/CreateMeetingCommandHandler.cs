using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mmu.CleanDddSimple.CrossCutting.Errors;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Eithers;
using Mmu.CleanDddSimple.CrossCutting.Services.Logging;
using Mmu.CleanDddSimple.Domain.Models;
using Mmu.CleanDddSimple.Domain.Services;

namespace Mmu.CleanDddSimple.Application.UseCases.CreateMeeting
{
    public class CreateMeetingCommandHandler : IRequestHandler<CreateMeetingCommand, Either<ServerError, MeetingCreatedResultDto>>
    {
        private readonly ILoggingService _loggingService;
        private readonly IMeetingService _meetingService;

        public CreateMeetingCommandHandler(
            ILoggingService loggingService,
            IMeetingService meetingService)
        {
            _loggingService = loggingService;
            _meetingService = meetingService;
        }

        public async Task<Either<ServerError, MeetingCreatedResultDto>> Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
        {
            _loggingService.LogInformation("Creating new Meeting..");

            var meetingResult = await _meetingService.TryCreatingMeetingAsync(
                request.Name,
                request.Description,
                (MeetingType)request.Type);

            var resultDto = meetingResult.MapRight(
                meeting => new MeetingCreatedResultDto
                {
                    MeetingId = meeting.Id
                });

            return resultDto;
        }
    }
}