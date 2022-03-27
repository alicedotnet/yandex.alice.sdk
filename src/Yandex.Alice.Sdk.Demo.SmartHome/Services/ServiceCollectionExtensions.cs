namespace Yandex.Alice.Sdk.Demo.SmartHome.Services;

using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSmartHomeServices(this IServiceCollection services)
    {
        services.AddSingleton<IContextUserService, ContextUserService>();
        services.AddSingleton<IDeviceService, DeviceService>();

        return services;
    }
}