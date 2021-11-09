namespace Yandex.Alice.Sdk.Demo.Workers
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Yandex.Alice.Sdk.Demo.Extensions;
    using Yandex.Alice.Sdk.Demo.Services.Interfaces;

    public class CleanResourcesWorker : Worker
    {
        protected override TimeSpan TimerInterval { get; }

        public CleanResourcesWorker(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            TimerInterval = TimeSpan.FromDays(1);
        }

        protected override void DoWork(object state)
        {
            using var scope = ServiceProvider.CreateScope();
            try
            {
                var cleanService = scope.ServiceProvider.GetRequiredService<ICleanService>();
                cleanService.CleanResourcesAsync().Wait();
            }
            catch (Exception e)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<CleanResourcesWorker>>();
                logger.UnexpectedError(e);
            }
        }
    }
}
