namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    public class DialogsApiResponse
    {
        public bool IsSuccess { get; }

        public string ErrorMessage { get; }

        public string ErrorCode { get; }

        protected DialogsApiResponse(bool isSuccess = true)
        {
            IsSuccess = isSuccess;
        }

        protected DialogsApiResponse(string errorMessage, string errorCode = null)
        {
            IsSuccess = false;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }
    }
}
