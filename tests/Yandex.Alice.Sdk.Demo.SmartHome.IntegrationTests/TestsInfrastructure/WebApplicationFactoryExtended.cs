namespace Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests.TestsInfrastructure
{
    using System;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.FileProviders;
    using Microsoft.Extensions.Hosting;
    using Yandex.Alice.Sdk.Models.DialogsApi;
    using Yandex.Alice.Sdk.Services;

    public class WebApplicationFactoryExtended : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return base.CreateHostBuilder()
                .ConfigureAppConfiguration(Configure)
                .ConfigureServices(ConfigureServices);
        }

        private void Configure(IConfigurationBuilder builder)
        {
            var provider = new PhysicalFileProvider(Environment.CurrentDirectory);
            builder
                .AddJsonFile(provider, "appsettings.tests.json", false, false)
                .AddEnvironmentVariables()
                .AddUserSecrets<WebApplicationFactoryExtended>();
        }

        private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            var configuration = context.Configuration;

            var aliceSettings = new AliceSettings(
                configuration.GetSection("AliceSettings:SmartHomeSkillId").Value,
                configuration.GetSection("AliceSettings:IotOAuthToken").Value);
            services.AddSingleton(aliceSettings);

            var apiSettings = new DialogsApiSettings(configuration.GetSection("AliceSettings:DialogsOAuthToken").Value);
            services.AddSingleton(apiSettings);
            services.AddSingleton<IDialogsApiService, DialogsApiService>();

            services.AddSingleton<IIoTApiService, IoTApiService>();
        }
    }
}
