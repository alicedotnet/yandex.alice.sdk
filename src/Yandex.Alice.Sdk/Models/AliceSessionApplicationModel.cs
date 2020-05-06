using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceSessionApplicationModel
    {

        [JsonPropertyName("application_id")]
        public string ApplicationId { get; set; }
    }
}
