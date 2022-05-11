using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mmu.CleanDddSimple.CrossCutting.Errors;
using Mmu.CleanDddSimple.CrossCutting.Errors.Implementation;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Eithers;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Maybes;
using Mmu.CleanDddSimple.Domain.Data.Repositories;
using Mmu.CleanDddSimple.Domain.Data.UnitOfWorks;
using Mmu.CleanDddSimple.Domain.Models;

namespace Mmu.CleanDddSimple.Application.UseCases.AddParticipant
{
    public class AddParticipantCommandHandler : IRequestHandler<AddParticipantCommand, Maybe<ServerError>>
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public AddParticipantCommandHandler(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task<Maybe<ServerError>> Handle(AddParticipantCommand request, CancellationToken cancellationToken)
        {
            using var uow = _uowFactory.Create();

            var meetingRepo = uow.GetRepository<IMeetingRepository>();
            var meetingMaybe = await meetingRepo.LoadSingleAsync(request.MeetingId);

            var result = await meetingMaybe
                .ToEither<ServerError, IMeeting>(() => new AggregateNotExistingError<IMeeting>(request.MeetingId))
                .MapEitherRight(meeting => meeting.AddParticipant(request.ParticipantName))
                .WhenRightAsync(_ => uow.SaveAsync());

            return result.ToLeftMaybe();
        }
    }
}