using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.BackgroundJobs;

namespace Acme.BookStore.BackgroundJobs
{
    public class EmailSendingArgs2
    {
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
