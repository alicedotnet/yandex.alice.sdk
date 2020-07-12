using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Helpers
{
    public static class AliceHelper
    {
        public const string DefaultReducedStringEnding = "...";

        public static string PrepareGalleryCardItemTitle(string title, string reducedEnding = DefaultReducedStringEnding)
        {
            return PrepareGalleryCardItemTitle(title, string.Empty, reducedEnding);
        }

        public static string PrepareGalleryCardItemTitle(string title, string mandatoryEnding, string reducedEnding = DefaultReducedStringEnding)
        {
            return ReduceString(title, AliceGalleryCardItem.MaxTitleLength, mandatoryEnding, reducedEnding);
        }

        public static string ReduceString(string value, int maxLenght, string mandatoryEnding, string reducedEnding)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if(mandatoryEnding == null)
            {
                throw new ArgumentNullException(nameof(mandatoryEnding));
            }
            if (reducedEnding == null)
            {
                throw new ArgumentNullException(nameof(reducedEnding));
            }

            if (value.Length + mandatoryEnding.Length <= maxLenght)
            {
                return value + mandatoryEnding;
            }
            int maxReducedStringLength = maxLenght - mandatoryEnding.Length - reducedEnding.Length;
            string reducedString = value.Substring(0, maxReducedStringLength);
            int lastWhitespaceIndex = reducedString.LastIndexOf(" ", StringComparison.OrdinalIgnoreCase);
            reducedString = reducedString.Substring(0, lastWhitespaceIndex);
            return reducedString.TrimEnd('.', ',', '-', ':') + reducedEnding + mandatoryEnding;
        }

        public static T JsonElementToObject<T>(object jsonElement)
        {
            if(jsonElement is JsonElement element)
            {
                return JsonElementToObject<T>(element);
            }
            return default;
        }

        public static T JsonElementToObject<T>(JsonElement jsonElement)
        {
            var json = jsonElement.GetRawText();
            return JsonSerializer.Deserialize<T>(json);
        }

        #region Text to speach

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


        #endregion
    }
}
