using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.LoadMeetingsOverview.Dtos;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.LoadMeetingsOverview.Specs;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Querying;

namespace Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.LoadMeetingsOverview.Interactors.Implementation
{
    public class LoadMeetingsOverviewInteractor : ILoadMeetingsOverviewInteractor
    {
        private readonly IQueryService _queryService;

        public LoadMeetingsOverviewInteractor(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<IReadOnlyCollection<MeetingOverviewDto>> ExecuteAsync()
        {
            var spec = new LoadMeetingsOverviewSpec();
            var dtos = await _queryService.QueryAsync(spec);

            return dtos;
        }
    }
}