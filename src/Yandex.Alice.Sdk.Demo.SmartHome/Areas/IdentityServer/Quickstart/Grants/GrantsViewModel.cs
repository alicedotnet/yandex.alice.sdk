// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Yandex.Alice.Sdk.Demo.SmartHome.Areas.IdentityServer.Quickstart.Grants;

using System.Collections.Generic;

public class GrantsViewModel
{
    public IEnumerable<GrantViewModel> Grants { get; init; }
}