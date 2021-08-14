// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace IdentityServerHost.Quickstart.UI
{
    public static class ConsentOptions
    {
        public static bool EnableOfflineAccess { get; set; } = true;

        public static string OfflineAccessDisplayName { get; set; } = "Offline Access";

        public static string OfflineAccessDescription { get; set; } = "Access to your applications and resources, even when you are offline";

        public static readonly string MustChooseOneErrorMessage = "You must pick at least one permission";
        public static readonly string InvalidSelectionErrorMessage = "Invalid selection";
    }
}
