namespace Mmu.CleanDddSimple.Domain.Data.UnitOfWorks
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}