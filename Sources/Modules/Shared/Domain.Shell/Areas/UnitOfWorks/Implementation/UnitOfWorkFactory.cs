using Lamar;
using Mmu.CleanDdd.Shared.Domain.Areas.Services.UnitOfWorks;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Factories;

namespace Mmu.CleanDdd.Shared.Domain.Shell.Areas.UnitOfWorks.Implementation
{
    internal class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IContainer _container;
        private readonly IAppDbContextFactory _dbContextFactory;

        public UnitOfWorkFactory(
            IContainer container,
            IAppDbContextFactory dbContextFactory)
        {
            _container = container;
            _dbContextFactory = dbContextFactory;
        }

        public IUnitOfWork Create()
        {
            var dbContext = _dbContextFactory.Create();
            var unitOfWork = _container.GetInstance<UnitOfWork>();
            unitOfWork.Initialize(dbContext);

            return unitOfWork;
        }
    }
}