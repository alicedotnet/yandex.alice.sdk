namespace Yandex.Alice.Sdk.Exceptions
{
    using System;

    public abstract class AliceException : Exception
    {
        protected AliceException(string message)
            : base(message)
        {
        }

        protected AliceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected AliceException()
        {
        }
    }
}
