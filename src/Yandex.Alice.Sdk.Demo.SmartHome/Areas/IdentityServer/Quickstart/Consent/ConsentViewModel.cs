// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Yandex.Alice.Sdk.Demo.SmartHome.Areas.IdentityServer.Quickstart.Consent;

using System.Collections.Generic;

public class ConsentViewModel : ConsentInputModel
{
    public string ClientName { get; init; }

    public string ClientUrl { get; init; }

    public string ClientLogoUrl { get; init; }

    public bool AllowRememberConsent { get; init; }

    public IEnumerable<ScopeViewModel> IdentityScopes { get; set; }

    public IEnumerable<ScopeViewModel> ApiScopes { get; set; }
}