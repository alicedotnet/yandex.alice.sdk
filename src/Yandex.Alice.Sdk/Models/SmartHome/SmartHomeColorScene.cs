namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class SmartHomeColorScene
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        public SmartHomeColorScene(string id)
        {
            Id = id;
        }
    }
}
