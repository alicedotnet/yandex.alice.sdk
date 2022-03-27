namespace Yandex.Alice.Sdk.Helpers
{
    using System;
    using System.Text.Json;
    using System.Text.RegularExpressions;
    using Yandex.Alice.Sdk.Models;

    public static class AliceHelper
    {
        public const string DefaultReducedStringEnding = "...";

        public static string PrepareGalleryCardItemTitle(string title, string mandatoryEnding = "", string reducedEnding = DefaultReducedStringEnding)
        {
            return ReduceString(title, AliceGalleryCardItem.MaxTitleLength, mandatoryEnding, reducedEnding);
        }

        public static string GetSilenceString(long milliseconds)
        {
            return $"sil<[{milliseconds}]>";
        }

        public static string GetSpeakerTag(string audio)
        {
            return $"<speaker audio=\"{audio}\">";
        }

        internal static string GetStringWithoutTags(string value)
        {
            value = Regex.Replace(value, "<speaker audio=\".*\">", string.Empty, RegexOptions.IgnoreCase);
            return Regex.Replace(value, "sil<\\[.*\\]>", string.Empty, RegexOptions.IgnoreCase);
        }

        internal static T JsonElementToObject<T>(object jsonElement)
        {
            if (jsonElement is JsonElement element)
            {
                return JsonElementToObject<T>(element);
            }

            return default;
        }

        private static string ReduceString(string value, int maxLength, string mandatoryEnding, string reducedEnding)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (mandatoryEnding == null)
            {
                throw new ArgumentNullException(nameof(mandatoryEnding));
            }

            if (reducedEnding == null)
            {
                throw new ArgumentNullException(nameof(reducedEnding));
            }

            if (value.Length + mandatoryEnding.Length <= maxLength)
            {
                return value + mandatoryEnding;
            }

            var maxReducedStringLength = maxLength - mandatoryEnding.Length - reducedEnding.Length;
            var reducedString = value.Substring(0, maxReducedStringLength);
            var lastWhitespaceIndex = reducedString.LastIndexOf(" ", StringComparison.OrdinalIgnoreCase);
            reducedString = reducedString.Substring(0, lastWhitespaceIndex);
            return reducedString.TrimEnd('.', ',', '-', ':') + reducedEnding + mandatoryEnding;
        }

        private static T JsonElementToObject<T>(JsonElement jsonElement)
        {
            var json = jsonElement.GetRawText();
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
