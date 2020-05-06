using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceResponseModel : AliceModel
    {
        public const int TextMaxLenght = 1024;
        private string _text;

        [JsonPropertyName("text")]
        public string Text
        {
            get { return _text; }
            set
            {
                ValidateMaxLength(value, TextMaxLenght);
                _text = value;
            }
        }

        public const int TtsMaxLenght = 1024;
        private string _tts;
        [JsonPropertyName("tts")]
        public string Tts
        {
            get { return _tts; }
            set
            {
                ValidateMaxLength(value, TtsMaxLenght);
                _tts = value;
            }
        }

        [JsonPropertyName("end_session")]
        public bool EndSession { get; set; }

        [JsonPropertyName("buttons")]
        public List<AliceButtonModel> Buttons { get; set; }
    }
}
