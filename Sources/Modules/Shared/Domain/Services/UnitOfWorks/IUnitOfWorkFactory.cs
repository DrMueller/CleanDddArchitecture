namespace Mmu.CleanDdd.Shared.Domain.Services.UnitOfWorks
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}