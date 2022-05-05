using System;
using System.Threading.Tasks;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Repositories;

namespace Mmu.CleanDdd.SharedKernel.Domain.Areas.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        TRepo GetRepository<TRepo>()
            where TRepo : IRepository;

        Task SaveAsync();
    }
}