namespace Yandex.Alice.Sdk.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Yandex.Alice.Sdk.Helpers;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceResponseModel : AliceModel
    {
        private const int _textMaxLength = 1024;
        private const int _ttsMaxLength = 1024;

        private string _text;

        [JsonPropertyName("text")]
        public string Text
        {
            get => _text;

            set
            {
                _text = value;
                ValidateNotNull(_text);
                ValidateMaxLength(_text, _textMaxLength);
            }
        }

        private string _tts;

        [JsonPropertyName("tts")]
        public string Tts
        {
            get => _tts;

            set
            {
                _tts = value;
                ValidateMaxLength(AliceHelper.GetStringWithoutTags(_tts), _ttsMaxLength);
            }
        }

        [JsonPropertyName("end_session")]
        public bool EndSession { get; set; }

        [JsonPropertyName("directives")]
        public AliceDirectivesModel Directives { get; set; }

        [JsonPropertyName("buttons")]
        public List<AliceButtonModel> Buttons { get; set; }

        public AliceResponseModel()
        {
            Directives = new AliceDirectivesModel();
        }

        public void SetText(string text, bool setTts = true)
        {
            Text = PrepareText(text);
            if (setTts)
            {
                SetTts(text);
            }
        }

        public void AppendText(string text, bool setTts = true)
        {
            Text += PrepareText(text);
            if (setTts)
            {
                AppendTts(text);
            }
        }

        private static string PrepareText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            text = text.Replace("+", string.Empty);
            text = AliceHelper.GetStringWithoutTags(text);

            return text;
        }

        private void SetTts(string tts)
        {
            Tts = tts;
        }

        private void AppendTts(string tts)
        {
            Tts += tts;
        }
    }
}
