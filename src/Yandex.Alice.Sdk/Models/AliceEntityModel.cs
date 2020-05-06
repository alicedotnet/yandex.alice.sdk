using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Yandex.Alice.Sdk.Converters;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceEntityModel
    {
        [JsonPropertyName("tokens")]
        public AliceTokensModel Tokens { get; set; }

        [JsonPropertyName(Constants.AliceEntityModelFields.Type)]
        [JsonConverter(typeof(AliceEntityTypeConverter))]
        public AliceEntityType Type { get; set; }
    }
}
