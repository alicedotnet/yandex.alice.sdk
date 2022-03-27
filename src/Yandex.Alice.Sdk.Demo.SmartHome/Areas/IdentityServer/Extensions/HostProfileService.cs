namespace Yandex.Alice.Sdk.Demo.SmartHome.Areas.IdentityServer.Extensions;

using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Test;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

[UsedImplicitly]
public class HostProfileService : TestUserProfileService
{
    public HostProfileService(TestUserStore users, ILogger<HostProfileService> logger)
        : base(users, logger)
    {
    }

    public override async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        await base.GetProfileDataAsync(context);

        var transaction = context.RequestedResources.ParsedScopes.FirstOrDefault(x => x.ParsedName == "transaction");
        if (transaction?.ParsedParameter != null)
        {
            context.IssuedClaims.Add(new Claim("transaction_id", transaction.ParsedParameter));
        }
    }
}