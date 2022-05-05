namespace Mmu.CleanDddSimple.Infrastructure.DataAccess.UnitOfWorks
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}