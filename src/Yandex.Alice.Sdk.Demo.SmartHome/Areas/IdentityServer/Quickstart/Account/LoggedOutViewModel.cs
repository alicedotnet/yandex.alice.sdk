// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Yandex.Alice.Sdk.Demo.SmartHome.Areas.IdentityServer.Quickstart.Account;

public class LoggedOutViewModel
{
    public string PostLogoutRedirectUri { get; init; }

    public string ClientName { get; init; }

    public string SignOutIframeUrl { get; init; }

    public bool AutomaticRedirectAfterSignOut { get; init; }

    public string LogoutId { get; set; }

    public bool TriggerExternalSignOut => ExternalAuthenticationScheme != null;

    public string ExternalAuthenticationScheme { get; set; }
}