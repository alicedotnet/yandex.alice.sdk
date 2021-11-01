namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceRequestModel<TIntents> : AliceRequestModelBase
    {
        [JsonPropertyName("nlu")]
        public AliceNluModel<TIntents> Nlu { get; set; }
    }
}
