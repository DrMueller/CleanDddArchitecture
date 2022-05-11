using System.Threading.Tasks;
using Mmu.CleanDddSimple.Infrastructure.Application.Mediation.Models;

namespace Mmu.CleanDddSimple.Infrastructure.Application.Mediation.Services
{
    public interface IMediationService
    {
        Task<T> SendAsync<T>(ICommand<T> command);

        Task SendAsync(ICommand command);

        Task<T> SendAsync<T>(IQuery<T> query);
    }
}