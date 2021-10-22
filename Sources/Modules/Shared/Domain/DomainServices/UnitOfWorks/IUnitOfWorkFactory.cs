namespace Mmu.CleanDdd.Shared.Domain.DomainServices.UnitOfWorks
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}