using Lamar;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.UnitOfWorks;
using Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.DbContexts.Factories;

namespace Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.UnitOfWorks.Implementation
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