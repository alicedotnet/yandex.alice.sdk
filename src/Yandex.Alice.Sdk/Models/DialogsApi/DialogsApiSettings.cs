namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    public class DialogsApiSettings
    {
        public string DialogsOAuthToken { get; }

        public string BaseAddress { get; }

        public DialogsApiSettings(string dialogsOAuthToken, string baseAddress = "https://dialogs.yandex.net")
        {
            DialogsOAuthToken = dialogsOAuthToken;
            BaseAddress = baseAddress;
        }
    }
}
