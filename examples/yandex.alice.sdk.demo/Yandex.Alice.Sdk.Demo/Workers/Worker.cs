using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Yandex.Alice.Sdk.Demo.Workers
{
    public abstract class Worker : BackgroundService
    {
        protected abstract TimeSpan TimerInterval { get; }
        protected IServiceProvider ServiceProvider { get; }
        private Timer _timer;

        protected Worker(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimerInterval);
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return base.StopAsync(cancellationToken);
        }

        protected abstract void DoWork(object state);
    }
}
