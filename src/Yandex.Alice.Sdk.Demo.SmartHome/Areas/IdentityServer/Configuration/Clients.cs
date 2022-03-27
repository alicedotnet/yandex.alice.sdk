// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Yandex.Alice.Sdk.Demo.SmartHome.Areas.IdentityServer.Configuration;

using System.Collections.Generic;
using IdentityServer4.Models;
using SmartHomeIdentityServer;

public static class Clients
{
    public static IEnumerable<Client> Get()
    {
        var clients = new List<Client>();

        clients.AddRange(ClientsConsole.Get());
        clients.AddRange(ClientsWeb.Get());
        clients.AddRange(ClientsAlice.Get());

        return clients;
    }
}