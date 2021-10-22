using System;
using System.Threading.Tasks;
using Mmu.CleanDdd.Shared.Domain.DomainServices.Repositories;

namespace Mmu.CleanDdd.Shared.Domain.DomainServices.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        TRepo GetRepository<TRepo>()
            where TRepo : IRepository;

        Task SaveAsync();
    }
}