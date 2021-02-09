using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceDirectivesModel
    {
        [JsonPropertyName("request_geolocation")]
        public object RequestGeolocation { get; set; }

        public void SetRequestGeolocation()
        {
            RequestGeolocation = new object();
        }
    }
}
