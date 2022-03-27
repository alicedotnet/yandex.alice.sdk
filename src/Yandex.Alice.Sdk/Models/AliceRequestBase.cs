namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceRequestBase<TSession, TUser>
    {
        [JsonPropertyName("state")]
        public AliceStateModel<TSession, TUser> State { get; set; }

        [JsonPropertyName("meta")]
        public AliceMetaModel Meta { get; set; }

        [JsonPropertyName("session")]
        public AliceSessionModel Session { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
