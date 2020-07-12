using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Yandex.Alice.Sdk.Converters
{
    public class DialogsDateConverter : DateTimeOffsetConverter
    {
        public DialogsDateConverter() 
            : base(AliceConstants.DateTimeFormat)
        {
        }
    }
}
