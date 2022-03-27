namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceGalleryCardFooterModel
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("button")]
        public AliceImageCardButtonModel Button { get; set; }

        public AliceGalleryCardFooterModel()
        {
        }

        public AliceGalleryCardFooterModel(string text, AliceImageCardButtonModel button = null)
        {
            Text = text;
            Button = button;
        }
    }
}
