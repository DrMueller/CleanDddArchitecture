using System;
using System.Net.Mail;

namespace Mmu.CleanDdd.Shared.Application.Shell.Areas.Emails.Services.Servants.Implementation
{
    public sealed class SmtpClientProxy : ISmtpClientProxy
    {
        private readonly SmtpClient _smtpClient;
        private bool _disposed;

        public SmtpClientProxy(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        ~SmtpClientProxy()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Send(MailMessage mailMessage)
        {
            _smtpClient.Send(mailMessage);
        }

        private void Dispose(bool disposedByCode)
        {
            if (_disposed)
            {
                return;
            }

            if (disposedByCode)
            {
                _smtpClient.Dispose();
            }

            _disposed = true;
        }
    }
}