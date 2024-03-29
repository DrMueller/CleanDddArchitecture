﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using Mmu.CleanDddSimple.Areas.Domain.Repositories;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Types.Maybes;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.UnitOfWorks;

namespace Mmu.CleanDddSimple.Areas.Application.UseCases.LoadMeeting
{
    [UsedImplicitly]
    public class LoadMeetingQueryHandler : IRequestHandler<LoadMeetingQuery, Maybe<LoadMeetingResultDto>>
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public LoadMeetingQueryHandler(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task<Maybe<LoadMeetingResultDto>> Handle(LoadMeetingQuery request, CancellationToken cancellationToken)
        {
            using var uow = _uowFactory.Create();

            var meeting = await uow
                .GetRepository<IMeetingRepository>()
                .LoadSingleAsync(request.MeetingId);

            var dto = meeting.Map(
                m => new LoadMeetingResultDto
                {
                    MeetingId = m.Id,
                    Participants = m.Participants.Select(f => f.Name).ToList()
                });

            return dto;
        }
    }
}