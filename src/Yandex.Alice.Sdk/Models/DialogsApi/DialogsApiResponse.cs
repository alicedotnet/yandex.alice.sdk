namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    public class DialogsApiResponse
    {
        public bool IsSuccess { get; }

        public string ErrorMessage { get; }

        public string ErrorCode { get; }

        public DialogsApiResponse(bool isSuccess = true)
        {
            IsSuccess = isSuccess;
        }

        public DialogsApiResponse(string errorMessage, string errorCode = null)
        {
            IsSuccess = false;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }
    }
}
