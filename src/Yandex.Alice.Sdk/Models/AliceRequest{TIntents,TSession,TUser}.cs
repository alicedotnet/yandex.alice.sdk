namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceRequest<TIntents, TSession, TUser>
        : AliceRequestBase<TSession, TUser>
    {
        [JsonPropertyName("request")]
        public AliceRequestModel<TIntents> Request { get; set; }
    }
}
