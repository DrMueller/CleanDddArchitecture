using System;
using System.Threading.Tasks;
using Mmu.CleanDdd.Shared.Domain.Areas.Services.Repositories;

namespace Mmu.CleanDdd.Shared.Domain.Areas.Services.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        TRepo GetRepository<TRepo>()
            where TRepo : IRepository;

        Task SaveAsync();
    }
}