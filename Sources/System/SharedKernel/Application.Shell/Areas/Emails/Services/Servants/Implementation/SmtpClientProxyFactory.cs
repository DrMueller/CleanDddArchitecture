using System.Net;
using System.Net.Mail;
using Mmu.CleanDdd.CrossCutting.Areas.Settings.Provisioning.Services;

namespace Mmu.CleanDdd.SharedKernel.Application.Shell.Areas.Emails.Services.Servants.Implementation
{
    public class SmtpClientProxyFactory : ISmtpClientProxyFactory
    {
        private readonly IAppSettingsProvider _settingsProvider;

        public SmtpClientProxyFactory(IAppSettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public ISmtpClientProxy CreateProxy()
        {
            var settings = _settingsProvider.Settings.EmailSettings;

            var smtpClient = new SmtpClient(
                settings.Host,
                settings.Port) { UseDefaultCredentials = false, Credentials = new NetworkCredential(settings.UserName, settings.Password), DeliveryMethod = SmtpDeliveryMethod.Network, EnableSsl = true };

            return new SmtpClientProxy(smtpClient);
        }
    }
}