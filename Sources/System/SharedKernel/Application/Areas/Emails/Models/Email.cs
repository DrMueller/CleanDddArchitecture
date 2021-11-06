using System.Collections.Generic;
using Mmu.CleanDdd.CrossCutting.Areas.LanguageExtensions.Invariance;

namespace Mmu.CleanDdd.SharedKernel.Application.Areas.Emails.Models
{
    public class Email
    {
        public EmailBody Body { get; }
        public string FromAddress { get; }
        public string Subject { get; }
        public IReadOnlyCollection<string> ToAddresses { get; }

        public Email(string fromAddress, IReadOnlyCollection<string> toAddresses, string subject, EmailBody body)
        {
            Guard.StringNotNullOrEmpty(() => fromAddress);
            Guard.ObjectNotNull(() => toAddresses);
            Guard.That(() => toAddresses.Count > 0, "E-Mail must have at least one TO-Address");
            Guard.StringNotNullOrEmpty(() => subject);
            Guard.ObjectNotNull(() => body);

            FromAddress = fromAddress;
            ToAddresses = toAddresses;
            Subject = subject;
            Body = body;
        }
    }
}