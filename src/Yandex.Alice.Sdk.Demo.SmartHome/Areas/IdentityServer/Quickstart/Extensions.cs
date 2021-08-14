namespace IdentityServerHost.Quickstart.UI
{
    using System;
    using IdentityServer4.Models;
    using Microsoft.AspNetCore.Mvc;

    public static class Extensions
    {
        /// <summary>
        /// Checks if the redirect URI is for a native client.
        /// </summary>
        public static bool IsNativeClient(this AuthorizationRequest context)
        {
            return !context.RedirectUri.StartsWith("https", StringComparison.Ordinal)
               && !context.RedirectUri.StartsWith("http", StringComparison.Ordinal);
        }

        public static IActionResult LoadingPage(this Controller controller, string viewName, string redirectUri)
        {
            controller.HttpContext.Response.StatusCode = 200;
            controller.HttpContext.Response.Headers["Location"] = string.Empty;

            return controller.View(viewName, new RedirectViewModel { RedirectUrl = redirectUri });
        }
    }
}
