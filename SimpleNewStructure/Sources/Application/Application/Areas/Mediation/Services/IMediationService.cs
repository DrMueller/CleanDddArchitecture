using System.Threading.Tasks;
using Mmu.CleanDddSimple.Application.Areas.Mediation.Models;

namespace Mmu.CleanDddSimple.Application.Areas.Mediation.Services
{
    public interface IMediationService
    {
        Task<T> SendAsync<T>(ICommand<T> command);

        Task SendAsync(ICommand command);

        Task<T> SendAsync<T>(IQuery<T> query);
    }
}