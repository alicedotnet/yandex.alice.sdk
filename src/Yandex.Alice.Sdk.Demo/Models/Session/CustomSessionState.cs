using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Yandex.Alice.Sdk.Demo.Models.Session
{
    public class CustomSessionState
    {
        [JsonPropertyName("mode")]
        public ModeType Mode { get; set; }

        public CustomSessionState(ModeType mode)
        {
            Mode = mode;
        }

        public CustomSessionState()
        {
        }
    }
}
