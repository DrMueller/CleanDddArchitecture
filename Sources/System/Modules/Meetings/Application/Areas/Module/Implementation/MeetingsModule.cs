using Lamar;
using Mmu.CleanDdd.Meetings.Application.Areas.UseCases;

namespace Mmu.CleanDdd.Meetings.Application.Areas.Module.Implementation
{
    public class MeetingsModule : IMeetingsModule
    {
        private readonly IContainer _container;

        public MeetingsModule(IContainer container)
        {
            this._container = container;
        }

        public T GetInteractor<T>() where T : IMeetingsModuleInteractor
        {
            return _container.GetInstance<T>();
        }
    }
}