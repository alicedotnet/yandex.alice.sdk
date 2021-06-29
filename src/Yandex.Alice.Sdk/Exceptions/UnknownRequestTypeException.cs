namespace Yandex.Alice.Sdk.Exceptions
{
    using System;

    public class UnknownRequestTypeException : AliceException
    {
        public UnknownRequestTypeException(string message)
            : base(message)
        {
        }

        public UnknownRequestTypeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public UnknownRequestTypeException()
        {
        }
    }
}
