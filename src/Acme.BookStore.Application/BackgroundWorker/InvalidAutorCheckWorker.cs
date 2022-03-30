using Acme.BookStore.Authors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Threading;

namespace Acme.BookStore.BackgroundWorker
{
    public class InvalidAutorCheckWorker : AsyncPeriodicBackgroundWorkerBase
    {
        public InvalidAutorCheckWorker(
                AbpAsyncTimer timer,
                IServiceScopeFactory serviceScopeFactory
            ) : base(
                timer,
                serviceScopeFactory)
        {
            Timer.Period = 6000;
        }

        protected async override Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
        {
            Logger.LogInformation("Starting: InvalidAutorCheckWorker..!");

            //Resolve dependencies
            var authorRepository = workerContext
                .ServiceProvider
                .GetRequiredService<IAuthorRepository>();

            //Do the work
            var author = await authorRepository.FindByNameAsync("aaa");
           
            Logger.LogInformation("Completed: InvalidAutorCheckWorker..!");
        }
    }
}
