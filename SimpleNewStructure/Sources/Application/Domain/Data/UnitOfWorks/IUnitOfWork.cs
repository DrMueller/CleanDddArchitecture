using System;
using System.Threading.Tasks;
using Mmu.CleanDddSimple.Domain.Data.Repositories;

namespace Mmu.CleanDddSimple.Domain.Data.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        TRepo GetRepository<TRepo>()
            where TRepo : IRepository;

        Task SaveAsync();
    }
}