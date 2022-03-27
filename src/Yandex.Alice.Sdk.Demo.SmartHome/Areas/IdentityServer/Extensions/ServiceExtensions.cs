namespace Yandex.Alice.Sdk.Demo.SmartHome.Areas.IdentityServer.Extensions;

using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Quickstart;

public static class ServiceExtensions
{
    public static IServiceCollection AddSmartHomeIdentityServer(this IServiceCollection services, IConfiguration configuration)
    {
        IdentityModelEventSource.ShowPII = true;

        // cookie policy to deal with temporary browser incompatibilities
        services
            .AddSameSiteCookiePolicy()
            .AddIdentityServer(options =>
            {
                options.Events.RaiseSuccessEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;

                options.EmitScopesAsSpaceDelimitedStringInJwt = true;
            })
            .Configure(configuration)
            .AddDeveloperSigningCredential()
            .AddExtensionGrantValidator<ExtensionGrantValidator>()
            .AddExtensionGrantValidator<NoSubjectExtensionGrantValidator>()
            .AddJwtBearerClientAuthentication()
            .AddAppAuthRedirectUriValidator()
            .AddTestUsers(TestUsers.Users)
            .AddProfileService<HostProfileService>()
            .AddCustomTokenRequestValidator<ParameterizedScopeTokenRequestValidator>()
            .AddScopeParser<ParameterizedScopeParser>();

        services.AddLocalApiAuthentication(principal =>
        {
            principal.Identities.First().AddClaim(new Claim("additional_claim", "additional_value"));

            return Task.FromResult(principal);
        });

        return services;
    }

    private static IIdentityServerBuilder Configure(this IIdentityServerBuilder identityServerBuilder, IConfiguration configuration)
    {
        var isPersistent = configuration.GetValue<bool>("IdentityServerPersistent");
        return isPersistent ? identityServerBuilder.AddSmartHomePersistent(configuration) : identityServerBuilder.AddSmartHomeInMemory();
    }

    private static IIdentityServerBuilder AddSmartHomeInMemory(this IIdentityServerBuilder identityServerBuilder)
    {
        return identityServerBuilder
            .AddInMemoryClients(Clients.Get())
            .AddInMemoryIdentityResources(Resources.IdentityResources)
            .AddInMemoryApiScopes(Resources.ApiScopes)
            .AddInMemoryApiResources(Resources.ApiResources);
    }

    private static IIdentityServerBuilder AddSmartHomePersistent(this IIdentityServerBuilder identityServerBuilder, IConfiguration configuration)
    {
        var migrationAssembly = typeof(ServiceExtensions).GetTypeInfo().Assembly.GetName().Name;
        var connectionString = configuration.GetConnectionString("IdentityServer");

        return identityServerBuilder
            .AddConfigurationStore(opt =>
            {
                opt.ConfigureDbContext = c => c.UseSqlite(
                    connectionString,
                    sql => sql.MigrationsAssembly(migrationAssembly));
            })
            .AddOperationalStore(opt =>
            {
                opt.ConfigureDbContext = o => o.UseSqlite(
                    connectionString,
                    sql => sql.MigrationsAssembly(migrationAssembly));
            });
    }
}