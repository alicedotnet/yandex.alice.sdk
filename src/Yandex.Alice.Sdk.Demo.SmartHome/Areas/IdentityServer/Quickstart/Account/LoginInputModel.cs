// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Yandex.Alice.Sdk.Demo.SmartHome.Areas.IdentityServer.Quickstart.Account;

using System.ComponentModel.DataAnnotations;

public class LoginInputModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; init; }

    public bool RememberLogin { get; set; }

    public string ReturnUrl { get; init; }
}