using System;
using System.Net.Mail;

namespace Mmu.CleanDdd.Shared.Application.Shell.Areas.Emails.Services.Servants
{
    public interface ISmtpClientProxy : IDisposable
    {
        void Send(MailMessage mailMessage);
    }
}