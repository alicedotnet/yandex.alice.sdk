// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.using System.Collections.Generic;

namespace Yandex.Alice.Sdk.Demo.SmartHome.Areas.IdentityServer.Configuration;

using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

public static class ClientsWeb
{
    private static readonly string[] _allowedScopes =
    {
        IdentityServerConstants.StandardScopes.OpenId,
        IdentityServerConstants.StandardScopes.Profile,
        IdentityServerConstants.StandardScopes.Email,
        "resource1.scope1",
        "resource2.scope1",
        "transaction",
    };

    public static IEnumerable<Client> Get()
    {
        return new List<Client>
        {
            ///////////////////////////////////////////
            // JS OIDC Sample
            //////////////////////////////////////////
            new ()
            {
                ClientId = "js_oidc",
                ClientName = "JavaScript OIDC Client",
                ClientUri = "https://identityserver.io",

                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,

                RedirectUris =
                {
                    "https://localhost:44300/index.html",
                    "https://localhost:44300/callback.html",
                    "https://localhost:44300/silent.html",
                    "https://localhost:44300/popup.html",
                },

                PostLogoutRedirectUris = { "https://localhost:44300/index.html" },
                AllowedCorsOrigins = { "https://localhost:44300" },

                AllowedScopes = _allowedScopes,
            },

            ///////////////////////////////////////////
            // MVC Automatic Token Management Sample
            //////////////////////////////////////////
            new ()
            {
                ClientId = @"mvc.tokenmanagement",

                ClientSecrets =
                {
                    new Secret("secret".Sha256()),
                },

                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,

                AccessTokenLifetime = 75,

                RedirectUris = { "https://localhost:44301/signin-oidc" },
                FrontChannelLogoutUri = @"https://localhost:44301/signout-oidc",
                PostLogoutRedirectUris = { @"https://localhost:44301/signout-callback-oidc" },

                AllowOfflineAccess = true,

                AllowedScopes = _allowedScopes,
            },

            ///////////////////////////////////////////
            // MVC Code Flow Sample
            //////////////////////////////////////////
            new ()
            {
                ClientId = "mvc.code",
                ClientName = "MVC Code Flow",
                ClientUri = "https://identityserver.io",

                ClientSecrets =
                {
                    new Secret("secret".Sha256()),
                },

                RequireConsent = true,
                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:44302/signin-oidc" },
                FrontChannelLogoutUri = @"https://localhost:44302/signout-oidc",
                PostLogoutRedirectUris = { @"https://localhost:44302/signout-callback-oidc" },

                AllowOfflineAccess = true,

                AllowedScopes = _allowedScopes,
            },

            ///////////////////////////////////////////
            // MVC Hybrid Flow Sample (Back Channel logout)
            //////////////////////////////////////////
            new ()
            {
                ClientId = "mvc.hybrid.backchannel",
                ClientName = "MVC Hybrid (with BackChannel logout)",
                ClientUri = "https://identityserver.io",

                ClientSecrets =
                {
                    new Secret("secret".Sha256()),
                },

                AllowedGrantTypes = GrantTypes.Hybrid,
                RequirePkce = false,

                RedirectUris = { "https://localhost:44303/signin-oidc" },
                BackChannelLogoutUri = "https://localhost:44303/logout",
                PostLogoutRedirectUris = { @"https://localhost:44303/signout-callback-oidc" },

                AllowOfflineAccess = true,

                AllowedScopes = _allowedScopes,
            },
        };
    }
}