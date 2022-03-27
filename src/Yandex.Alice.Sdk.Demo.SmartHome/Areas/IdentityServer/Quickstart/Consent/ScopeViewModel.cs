// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Yandex.Alice.Sdk.Demo.SmartHome.Areas.IdentityServer.Quickstart.Consent;

public class ScopeViewModel
{
    public string Value { get; init; }

    public string DisplayName { get; init; }

    public string Description { get; init; }

    public bool Emphasize { get; init; }

    public bool Required { get; init; }

    public bool Checked { get; init; }
}