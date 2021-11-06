namespace Mmu.CleanDdd.SharedKernel.Application.Areas.Emails.Models
{
    public class EmailBody
    {
        public string Content { get; }
        public bool IsHtmlBody { get; }

        public EmailBody(string content, bool isHtmlBody)
        {
            Content = content;
            IsHtmlBody = isHtmlBody;
        }
    }
}