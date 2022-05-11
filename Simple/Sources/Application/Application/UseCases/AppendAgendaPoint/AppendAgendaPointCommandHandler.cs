using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Maybes;
using Mmu.CleanDddSimple.Domain.Data.Repositories;
using Mmu.CleanDddSimple.Domain.Data.UnitOfWorks;

namespace Mmu.CleanDddSimple.Application.UseCases.AppendAgendaPoint
{
    [UsedImplicitly]
    public class AppendAgendaPointCommandHandler : IRequestHandler<AppendAgendaPointCommand>
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public AppendAgendaPointCommandHandler(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task<Unit> Handle(AppendAgendaPointCommand request, CancellationToken cancellationToken)
        {
            using var uow = _uowFactory.Create();

            var meetingRepo = uow.GetRepository<IMeetingRepository>();
            var meetingMaybe = await meetingRepo.LoadSingleAsync(request.MeetingId);

            var meeting = meetingMaybe.Reduce(() => throw new Exception());

            meeting.Agenda.AddAgendaPoint(request.AgendaPointDescription);

            await uow.SaveAsync();

            return Unit.Value;
        }
    }
}