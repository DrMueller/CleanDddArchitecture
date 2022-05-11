using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mmu.CleanDddSimple.Areas.Domain.Models;
using Mmu.CleanDddSimple.Areas.Domain.Services;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Errors;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Types.Eithers;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Services.Logging;

namespace Mmu.CleanDddSimple.Areas.Application.UseCases.CreateMeeting
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