using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
