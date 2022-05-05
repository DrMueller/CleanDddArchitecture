using System;
using System.Net.Mail;

namespace Mmu.CleanDdd.SharedKernel.Application.Shell.Areas.Emails.Services.Servants
{
    public interface ISmtpClientProxy : IDisposable
    {
        void Send(MailMessage mailMessage);
    }
}