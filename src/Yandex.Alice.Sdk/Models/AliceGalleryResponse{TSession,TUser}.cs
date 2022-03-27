namespace Yandex.Alice.Sdk.Models
{
    using System.Collections.Generic;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceGalleryResponse<TSession, TUser>
        : AliceResponseBase<AliceGalleryResponseModel, TSession, TUser>
    {
        public AliceGalleryResponse(AliceRequestBase<TSession, TUser> request, string text, bool keepSessionState = true, bool keepUserState = true)
            : this(request, text, text, keepSessionState, keepUserState)
        {
        }

        public AliceGalleryResponse(AliceRequestBase<TSession, TUser> request, string text, string tts, bool keepSessionState = true, bool keepUserState = true)
            : this(request, text, tts, new List<AliceButtonModel>(), keepSessionState, keepUserState)
        {
        }

        public AliceGalleryResponse(AliceRequestBase<TSession, TUser> request, string text, List<AliceButtonModel> buttons, bool keepSessionState = true, bool keepUserState = true)
            : this(request, text, text, buttons, keepSessionState, keepUserState)
        {
        }

        public AliceGalleryResponse(AliceRequestBase<TSession, TUser> request, string text, string tts, List<AliceButtonModel> buttons, bool keepSessionState = true, bool keepUserState = true)
            : base(request, text, tts, buttons, keepSessionState, keepUserState)
        {
        }
    }
}
