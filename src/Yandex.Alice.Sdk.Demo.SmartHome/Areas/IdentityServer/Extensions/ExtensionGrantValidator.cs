// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Yandex.Alice.Sdk.Demo.SmartHome.Areas.IdentityServer.Extensions;

using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using JetBrains.Annotations;

[UsedImplicitly]
public class ExtensionGrantValidator : IExtensionGrantValidator
{
    public Task ValidateAsync(ExtensionGrantValidationContext context)
    {
        var credential = context.Request.Raw.Get("custom_credential");

        context.Result = credential != null ? new GrantValidationResult("818727", "custom") : new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid custom credential");

        return Task.CompletedTask;
    }

    public string GrantType => "custom";
}