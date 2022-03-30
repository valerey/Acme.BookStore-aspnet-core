using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;

namespace Acme.BookStore.BackgroundWorker2
{
    public class BackgroundWorker : BackgroundWorkerBase
    {
        public override Task StartAsync(CancellationToken cancellationToken = default)
        {
            //...            
            return null;
        }

        public override Task StopAsync(CancellationToken cancellationToken = default)
        {
            //...
            return null;
        }
    }
}
