namespace Yandex.Alice.Sdk.Demo.SmartHome.SmartHomeIdentityServer
{
    using System.Collections.Generic;
    using IdentityServer4;
    using IdentityServer4.Models;

    public static class ClientsAlice
    {
        private static readonly string[] _allowedScopes =
        {
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile,
            IdentityServerConstants.StandardScopes.Email,
            IdentityServerConstants.StandardScopes.OfflineAccess,
            IdentityServerConstants.LocalApi.ScopeName,
            "resource1.scope1",
            "resource2.scope1",
            "transaction",
        };

        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                ///////////////////////////////////////////
                // Alice skill sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "alice",
                    ClientName = "Alice",
                    ClientUri = "http://identityserver.io",

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowOfflineAccess = true,
                    RequireClientSecret = false,

                    RedirectUris =
                    {
                        "https://social.yandex.net/broker/redirect",
                    },

                    PostLogoutRedirectUris = { "https://localhost:44300/index.html" },
                    AllowedCorsOrigins = { "https://localhost:44300" },

                    AllowedScopes = _allowedScopes,
                    RequirePkce = false,
                },
            };
        }
    }
}