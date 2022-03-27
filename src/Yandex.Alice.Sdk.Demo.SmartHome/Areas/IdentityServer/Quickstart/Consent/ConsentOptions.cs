// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Yandex.Alice.Sdk.Demo.SmartHome.Areas.IdentityServer.Quickstart.Consent;

public static class ConsentOptions
{
    public static bool EnableOfflineAccess => true;

    public static string OfflineAccessDisplayName => "Offline Access";

    public static string OfflineAccessDescription => "Access to your applications and resources, even when you are offline";

    public const string MustChooseOneErrorMessage = "You must pick at least one permission";
    public const string InvalidSelectionErrorMessage = "Invalid selection";
}