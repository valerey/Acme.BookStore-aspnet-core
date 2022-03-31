using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;

namespace Acme.BookStore.BackgroundWorker
{
    public class BackgroundWorker : BackgroundWorkerBase
    {
        public override Task StartAsync(CancellationToken cancellationToken = default)
        {
            Logger.LogInformation("BackgroundWorker StartAsync..!");
            return null;
        }

        public override Task StopAsync(CancellationToken cancellationToken = default)
        {
            Logger.LogInformation("BackgroundWorker StopAsync..!");
            return null;
        }
    }
}
