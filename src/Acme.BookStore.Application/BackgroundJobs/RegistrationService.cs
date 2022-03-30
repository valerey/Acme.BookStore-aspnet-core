using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.BackgroundJobs;
using Acme.BookStore.Authors;
using Acme.BookStore.BackgroudJobs;

namespace Acme.BookStore.BackgroundJobs
{
    public class RegistrationService : ApplicationService
    {
        private readonly IBackgroundJobManager _backgroundJobManager;

        public RegistrationService(IBackgroundJobManager backgroundJobManager)
        {
            _backgroundJobManager = backgroundJobManager;
        }  

        public async Task SendMailAsync(string emailAddress)
        {

            await _backgroundJobManager.EnqueueAsync(
                new EmailSendingArgs
                {
                    EmailAddress = emailAddress,
                    Subject = "You've successfully registered!",
                    Body = "..."
                }
            );
        }

        public async Task SendMail2Async(string emailAddress)
        {

            await _backgroundJobManager.EnqueueAsync(
                new EmailSendingArgs2
                {
                    EmailAddress = emailAddress,
                    Subject = "You've successfully registered!",
                    Body = "..."
                }
            );
        }

    }
}
