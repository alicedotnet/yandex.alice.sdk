namespace Yandex.Alice.Sdk.Demo.SmartHome;

using Areas.IdentityServer.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yandex.Alice.Sdk.Demo.SmartHome.Services;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddSmartHomeIdentityServer(Configuration)
            .AddSmartHomeServices()
            .AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
        });

        app.UseCertificateForwarding();
        app.UseCookiePolicy();

        app.UseDeveloperExceptionPage();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseIdentityServer();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapAreaControllerRoute(
                "IdentityServer",
                "IdentityServer",
                "{controller=Home}/{action=Index}/{id?}");

            endpoints.MapDefaultControllerRoute();
        });
    }
}