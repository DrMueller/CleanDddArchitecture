using Mmu.CleanDdd.Meetings.Application.Areas.UseCases;

namespace Mmu.CleanDdd.Meetings.Application.Areas.Module
{
    public interface IMeetingsModule
    {
        T GetInteractor<T>()
            where T : IMeetingsModuleInteractor;
    }
}