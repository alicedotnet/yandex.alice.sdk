namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    public class DialogsApiSettings
    {
        public string DialogsOAuthToken { get; }

        public DialogsApiSettings(string dialogsOAuthToken)
        {
            DialogsOAuthToken = dialogsOAuthToken;
        }
    }
}
