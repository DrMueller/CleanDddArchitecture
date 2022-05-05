using System;
using System.Threading.Tasks;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.Repositories;

namespace Mmu.CleanDddSimple.Infrastructure.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        TRepo GetRepository<TRepo>()
            where TRepo : IRepository;

        Task SaveAsync();
    }
}