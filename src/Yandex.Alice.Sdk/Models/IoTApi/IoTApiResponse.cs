namespace Yandex.Alice.Sdk.Models.IoTApi
{
    public class IoTApiResponse<T>
    {
        public bool IsSuccess { get; }

        public string ErrorMessage { get; }

        public T Content { get; }

        public IoTApiResponse(T content, string errorMessage = null, bool isSuccess = true)
        {
            Content = content;
            ErrorMessage = errorMessage;
            IsSuccess = isSuccess;
        }
    }
}
