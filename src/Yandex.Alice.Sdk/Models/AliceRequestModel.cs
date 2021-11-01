namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceRequestModel<TIntents> : AliceRequestModelBase
    {
        [JsonPropertyName("nlu")]
        public AliceNLUModel<TIntents> Nlu { get; set; }
    }
}
