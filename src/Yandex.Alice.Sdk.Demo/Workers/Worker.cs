namespace Yandex.Alice.Sdk.Demo.Workers;

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

public abstract class Worker : BackgroundService
{
    protected abstract TimeSpan TimerInterval { get; }

    protected IServiceProvider ServiceProvider { get; }

    private Timer _timer;

    protected Worker(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return base.StopAsync(cancellationToken);
    }

    public override void Dispose()
    {
        base.Dispose();

        _timer?.Dispose();
        GC.SuppressFinalize(this);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimerInterval);
        return Task.CompletedTask;
    }

    protected abstract void DoWork(object state);
}