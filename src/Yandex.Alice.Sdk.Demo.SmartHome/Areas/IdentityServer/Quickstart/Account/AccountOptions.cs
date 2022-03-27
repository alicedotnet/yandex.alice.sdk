// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Yandex.Alice.Sdk.Demo.SmartHome.Areas.IdentityServer.Quickstart.Account;

using System;

public static class AccountOptions
{
    public static bool AllowLocalLogin => true;

    public static bool AllowRememberLogin => true;

    public static TimeSpan RememberMeLoginDuration { get; } = TimeSpan.FromDays(30);

    public static bool ShowLogoutPrompt => true;

    public static bool AutomaticRedirectAfterSignOut => false;

    public static string InvalidCredentialsErrorMessage => "Invalid username or password";
}