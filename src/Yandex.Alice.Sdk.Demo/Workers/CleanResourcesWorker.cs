using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Yandex.Alice.Sdk.Demo.Models;
using Yandex.Alice.Sdk.Demo.Services.Interfaces;
using Yandex.Alice.Sdk.Models.DialogsApi;
using Yandex.Alice.Sdk.Services;

namespace Yandex.Alice.Sdk.Demo.Workers
{
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
                logger.LogError(e, string.Empty);
            }
        }
    }
}
