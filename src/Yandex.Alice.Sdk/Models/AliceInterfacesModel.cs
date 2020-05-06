using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceInterfacesModel
    {
        [JsonPropertyName("screen")]
        public object Screen { get; set; }
        [JsonPropertyName("payments")]
        public object Payments { get; set; }
        [JsonPropertyName("account_linking")]
        public object AccountLinking { get; set; }
    }
}
