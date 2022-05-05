using System.Threading.Tasks;
using Mmu.CleanDdd.SharedKernel.Application.Areas.Emails.Models;

namespace Mmu.CleanDdd.SharedKernel.Application.Areas.Emails.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Email email);
    }
}