using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mmu.CleanDddSimple.Areas.Domain.Models;
using Mmu.CleanDddSimple.Areas.Domain.Repositories;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Errors;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Errors.Implementation;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Types.Eithers;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Types.Maybes;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.UnitOfWorks;

namespace Mmu.CleanDddSimple.Areas.Application.UseCases.AddParticipant
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