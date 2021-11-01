namespace Mmu.CleanDdd.Shared.Domain.Areas.Services.UnitOfWorks
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}