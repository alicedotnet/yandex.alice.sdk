// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Yandex.Alice.Sdk.Demo.SmartHome.Areas.IdentityServer.Quickstart.Consent;

using System.Collections.Generic;

public class ConsentInputModel
{
    protected ConsentInputModel(string button = null)
    {
        Button = button;
    }

    public string Button { get; }

    public IEnumerable<string> ScopesConsented { get; init; }

    public bool RememberConsent { get; init; }

    public string ReturnUrl { get; init; }

    public string Description { get; init; }
}