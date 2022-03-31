using Acme.BookStore.BackgroundJobs;
using System;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;

namespace Acme.BookStore.BackgroudJobs
{
    public class EmailSendingJob2 : AsyncBackgroundJob<EmailSendingArgs2>, ITransientDependency
    {
        private readonly IEmailSender _emailSender;

        public EmailSendingJob2(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public override async Task ExecuteAsync(EmailSendingArgs2 args)
        {
           await _emailSender.SendAsync(
                args.EmailAddress,
                args.Subject,
                args.Body
            );
        }
    }
}
