namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    public class DialogsApiResponse<T> : DialogsApiResponse
    {
        public T Content { get; }

        public DialogsApiResponse(T content)
            : base(true)
        {
            Content = content;
        }

        public DialogsApiResponse(string errorMessage, string errorCode = null)
            : base(errorMessage, errorCode)
        {
        }
    }
}
