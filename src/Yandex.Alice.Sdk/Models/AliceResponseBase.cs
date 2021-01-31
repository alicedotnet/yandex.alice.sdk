using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public interface IAliceResponseBase
    {

    }

    public abstract class AliceResponseBase<TResponse, TSession, TUser>
        : IAliceResponseBase
        where TResponse : AliceResponseModel, new()
    {
        [JsonPropertyName("response")]
        public TResponse Response { get; set; }

        [JsonPropertyName("session_state")]
        public TSession SessionState { get; set; }

        [JsonPropertyName("user_state_update")]
        public TUser UserStateUpdate { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }


        protected AliceResponseBase()
        {

        }

        protected AliceResponseBase(AliceRequestBase<TSession, TUser> request, string text, string tts, List<AliceButtonModel> buttons, bool keepSessionState, bool keepUserState)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Version = request.Version;
            Response = new TResponse()
            {
                Text = text,
                Tts = tts,
                Buttons = buttons
            };

            if (keepSessionState)
            {
                if (request.State == null)
                {
                    throw new NullReferenceException(nameof(request.State));
                }
                SessionState = request.State.Session;
            }

            if(keepUserState)
            {
                if (request.State == null)
                {
                    throw new NullReferenceException(nameof(request.State));
                }
                UserStateUpdate = request.State.User;
            }
        }
    }
}
