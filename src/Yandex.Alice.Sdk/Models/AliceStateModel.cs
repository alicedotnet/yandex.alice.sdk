namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Yandex.Alice.Sdk.Helpers;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceStateModel<TSession, TUser>
    {
        [JsonPropertyName("session")]
        public TSession Session { get; set; }

        [JsonPropertyName("user")]
        public TUser User { get; set; }

        [JsonPropertyName("application")]
        public TUser Application { get; set; }

        [JsonIgnore]
        public TUser UserOrApplication => User != null ? User : Application;

        public T TryGetSession<T>()
        {
            return AliceHelper.JsonElementToObject<T>(Session);
        }

        public T TryGetUser<T>()
        {
            return AliceHelper.JsonElementToObject<T>(User);
        }
    }
}
