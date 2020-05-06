using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Yandex.Alice.Sdk.Helpers;
using Yandex.Alice.Sdk.Resources;

namespace Yandex.Alice.Sdk.Models
{
    public abstract class AliceModel
    {
        protected static void ValidateMaxLength(string value, int maxLength, [CallerMemberName] string propertyName = null)
        {
            if (value?.Length > maxLength)
            {
                string errorText = string.Format(CultureInfo.CurrentCulture, Yandex_Alice_Sdk_Resources.Error_TooLongString, maxLength, nameof(AliceHelper));
                throw new ArgumentException(errorText, propertyName);
            }
        }
    }
}
