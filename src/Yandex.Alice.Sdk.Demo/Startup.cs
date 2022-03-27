namespace Yandex.Alice.Sdk.Demo;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Yandex.Alice.Sdk.Demo.Models;
using Yandex.Alice.Sdk.Demo.Services;
using Yandex.Alice.Sdk.Demo.Services.Interfaces;
using Yandex.Alice.Sdk.Demo.Workers;
using Yandex.Alice.Sdk.Models.DialogsApi;
using Yandex.Alice.Sdk.Services;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        var skillId = Configuration["AliceSettings:SkillId"];
        var aliceSettings = new AliceSettings(skillId);
        var apiSettings = new DialogsApiSettings(Configuration["AliceSettings:DialogsOAuthToken"]);
        services.AddSingleton(apiSettings);
        services.AddSingleton<IDialogsApiService, DialogsApiService>();
        services.AddSingleton(aliceSettings);

        services.AddSingleton<IAliceService, AliceService>();
        services.AddSingleton<ICleanService, CleanService>();
        services.AddHostedService<CleanResourcesWorker>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}