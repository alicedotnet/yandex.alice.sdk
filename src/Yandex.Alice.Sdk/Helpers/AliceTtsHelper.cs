using System;
using System.Collections.Generic;
using System.Text;

namespace Yandex.Alice.Sdk.Helpers
{
    public static class AliceTtsHelper
    {
        /// <summary>
        /// Silence equal to 500ms
        /// </summary>
        public static readonly string SilenceString500 = GetSilenceString(500);

        /// <summary>
        /// Silence equal to 1000ms
        /// </summary>
        public static readonly string SilenceString1000 = GetSilenceString(1000);

        public static string GetSilenceString(long milliseconds)
        {
            return $"sil<[{milliseconds}]>";
        }
    }
}
