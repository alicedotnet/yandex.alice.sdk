using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Yandex.Alice.Sdk.Helpers
{
    [Obsolete("Use AliceHelper class instead")]
    //TODO::Remove this class in next package release
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

        public static string GetSpeakerTag(string audio)
        {
            return $"<speaker audio=\"{audio}\">";
        }

        internal static string GetTtsStringWithoutTags(string value)
        {
            return Regex.Replace(value, "<speaker audio=\".*\">", string.Empty, RegexOptions.IgnoreCase);
        }
    }
}
