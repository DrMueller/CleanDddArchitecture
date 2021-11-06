using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Mmu.CleanDdd.CrossCutting.Areas.LanguageExtensions.Invariance;
using Mmu.CleanDdd.SharedKernel.Application.Areas.Emails.Models;
using Mmu.CleanDdd.SharedKernel.Application.Areas.Emails.Services;
using Mmu.CleanDdd.SharedKernel.Application.Shell.Areas.Emails.Services.Servants;

namespace Mmu.CleanDdd.SharedKernel.Application.Shell.Areas.Emails.Services.Implementation
{
    public class EmailSender : IEmailSender
    {
        private readonly ISmtpClientProxyFactory _smtpClientProxyFactory;

        public EmailSender(ISmtpClientProxyFactory smtpClientProxyFactory)
        {
            _smtpClientProxyFactory = smtpClientProxyFactory;
        }

        public Task SendEmailAsync(Email email)
        {
            Guard.ObjectNotNull(() => email);

            return Task.Run(
                () =>
                {
                    var mailMessage = CreateMailMessage(email);

                    using var smtpClient = _smtpClientProxyFactory.CreateProxy();
                    smtpClient.Send(mailMessage);
                });
        }

        private static MailMessage CreateMailMessage(Email email)
        {
            var mailMessage = new MailMessage { From = new MailAddress(email.FromAddress) };

            foreach(var to in email.ToAddresses)
            {
                mailMessage.To.Add(to);
            }

            mailMessage.Subject = email.Subject;
            mailMessage.Body = email.Body.Content;
            mailMessage.IsBodyHtml = email.Body.IsHtmlBody;
            mailMessage.BodyEncoding = Encoding.UTF8;

            return mailMessage;
        }
    }
}