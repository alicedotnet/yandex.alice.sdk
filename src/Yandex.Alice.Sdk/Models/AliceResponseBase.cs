namespace Yandex.Alice.Sdk.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public abstract class AliceResponseBase<TResponse, TSession, TUser>
        : IAliceResponseBase, IAliceResponseStateBase<TSession, TUser>
        where TResponse : AliceResponseModel, new()
    {
        [JsonPropertyName("response")]
        public TResponse Response { get; set; }

        [JsonPropertyName("session_state")]
        public TSession SessionState { get; set; }

        [JsonPropertyName("user_state_update")]
        public TUser UserStateUpdate { get; set; }

        [JsonPropertyName("application_state")]
        public TUser ApplicationState { get; set; }

        [JsonIgnore]
        public TUser UserOrApplicationState
        {
            get
            {
                if (UserStateUpdate != null)
                {
                    return UserStateUpdate;
                }

                return ApplicationState;
            }
        }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        protected AliceResponseBase()
        {
        }

        protected AliceResponseBase(AliceRequestBase<TSession, TUser> request, string text, string tts, List<AliceButtonModel> buttons, bool keepSessionState = true, bool keepUserState = true)
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
                Buttons = buttons,
            };

            if (request.State != null)
            {
                if (keepSessionState)
                {
                    SessionState = request.State.Session;
                }

                if (keepUserState)
                {
                    UserStateUpdate = request.State.User;
                    ApplicationState = request.State.Application;
                }
            }
        }
    }

    public interface IAliceResponseBase
    {
    }

    public interface IAliceResponseStateBase<TSession, TUser>
    {
        [JsonPropertyName("session_state")]
        TSession SessionState { get; set; }

        [JsonPropertyName("user_state_update")]
        TUser UserStateUpdate { get; set; }

        [JsonPropertyName("application_state")]
        TUser ApplicationState { get; set; }

        [JsonIgnore]
        TUser UserOrApplicationState { get; }
    }
}
