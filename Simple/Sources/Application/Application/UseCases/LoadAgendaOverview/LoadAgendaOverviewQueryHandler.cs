using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using Mmu.CleanDddSimple.Domain.Data.Querying;

namespace Mmu.CleanDddSimple.Application.UseCases.LoadAgendaOverview
{
    [UsedImplicitly]
    public class LoadAgendaOverviewQueryHandler : IRequestHandler<LoadAgendaOverviewQuery, IReadOnlyCollection<AgendaOverviewResultDto>>
    {
        private readonly IQueryService _queryService;

        public LoadAgendaOverviewQueryHandler(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<IReadOnlyCollection<AgendaOverviewResultDto>> Handle(LoadAgendaOverviewQuery request, CancellationToken cancellationToken)
        {
            return await _queryService.QueryAsync(new AgendaOverviewSpec());
        }
    }
}