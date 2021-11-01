namespace Mmu.CleanDdd.Shared.Application.Shell.Areas.Emails.Services.Servants
{
    public interface ISmtpClientProxyFactory
    {
        ISmtpClientProxy CreateProxy();
    }
}