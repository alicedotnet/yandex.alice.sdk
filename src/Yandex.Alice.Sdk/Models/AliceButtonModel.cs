using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceButtonModel
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("payload")]
        public object Payload { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("hide")]
        public bool Hide { get; set; }

        public AliceButtonModel()
        {
            Payload = new object();
        }

        public AliceButtonModel(string title)
            : this(title, false, null, null)
        {

        }

        public AliceButtonModel(string title, bool hide)
            : this(title, hide, null, null)
        {

        }

        public AliceButtonModel(string title, bool hide, object payload, Uri url)
        {
            Title = title;
            Hide = hide;
            Payload = payload;
            Url = url;            
        }
    }
}
