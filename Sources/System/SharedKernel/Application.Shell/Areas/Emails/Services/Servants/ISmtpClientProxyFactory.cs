namespace Mmu.CleanDdd.SharedKernel.Application.Shell.Areas.Emails.Services.Servants
{
    public interface ISmtpClientProxyFactory
    {
        ISmtpClientProxy CreateProxy();
    }
}