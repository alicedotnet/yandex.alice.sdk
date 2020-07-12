using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    public class DialogsApiResponse
    {
        public bool IsSuccess { get; }
        public string ErrorMessage { get; }

        public DialogsApiResponse(bool isSuccess = true)
        {
            IsSuccess = isSuccess;
        }

        public DialogsApiResponse(string errorMessage)
        {
            IsSuccess = false;
            ErrorMessage = errorMessage;
        }
    }

    public class DialogsApiResponse<T> : DialogsApiResponse
    {
        public T Content { get; }

        public DialogsApiResponse(T content)
            : base(true)
        {
            Content = content;
        }

        public DialogsApiResponse(string errorMessage)
            : base(errorMessage)
        {

        }
    }
}
