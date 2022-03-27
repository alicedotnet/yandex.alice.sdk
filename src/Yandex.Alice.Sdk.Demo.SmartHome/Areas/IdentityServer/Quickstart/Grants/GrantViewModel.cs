// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Yandex.Alice.Sdk.Demo.SmartHome.Areas.IdentityServer.Quickstart.Grants;

using System;
using System.Collections.Generic;

public class GrantViewModel
{
    public string ClientId { get; init; }

    public string ClientName { get; init; }

    public string ClientLogoUrl { get; init; }

    public string Description { get; init; }

    public DateTime Created { get; init; }

    public DateTime? Expires { get; init; }

    public IEnumerable<string> IdentityGrantNames { get; init; }

    public IEnumerable<string> ApiGrantNames { get; init; }
}