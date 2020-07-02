using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Yandex.Alice.Sdk.Demo.Models
{
    public class CustomSessionState
    {
        [JsonPropertyName("isInIntentsTestingMode")]
        public bool IsInIntentsTestingMode { get; set; }

        public CustomSessionState(bool isInIntentsTestingMode)
        {
            IsInIntentsTestingMode = isInIntentsTestingMode;
        }

        public CustomSessionState()
        {
        }
    }
}
