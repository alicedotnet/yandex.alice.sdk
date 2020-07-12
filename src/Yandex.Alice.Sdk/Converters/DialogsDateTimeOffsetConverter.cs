using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Yandex.Alice.Sdk.Converters
{
    public class DialogsDateTimeOffsetConverter : DateTimeOffsetConverter
    {
        public DialogsDateTimeOffsetConverter() 
            : base(AliceConstants.DateTimeFormat)
        {
        }
    }
}
