namespace Mmu.CleanDdd.SharedKernel.Domain.Areas.UnitOfWorks
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}