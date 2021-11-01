using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.LoadMeetingsOverview.Dtos;

namespace Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.LoadMeetingsOverview.Interactors
{
    public interface ILoadMeetingsOverviewInteractor : IMeetingsModuleInteractor
    {
        Task<IReadOnlyCollection<MeetingOverviewResponseDto>> ExecuteAsync();
    }
}