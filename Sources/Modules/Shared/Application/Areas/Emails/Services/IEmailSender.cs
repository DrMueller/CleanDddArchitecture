using System.Threading.Tasks;
using Mmu.CleanDdd.Shared.Application.Areas.Emails.Models;

namespace Mmu.CleanDdd.Shared.Application.Areas.Emails.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Email email);
    }
}