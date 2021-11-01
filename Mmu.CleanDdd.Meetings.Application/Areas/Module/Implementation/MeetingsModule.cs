using Lamar;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases;

namespace Mmu.CleanDdd.Meetings.Application.Areas.Module.Implementation
{
    public class MeetingsModule : IMeetingsModule
    {
        private readonly IContainer container;

        public MeetingsModule(IContainer container)
        {
            this.container = container;
        }

        public T GetInteractor<T>() where T : IMeetingsModuleInteractor
        {
            return container.GetInstance<T>();
        }
    }
}