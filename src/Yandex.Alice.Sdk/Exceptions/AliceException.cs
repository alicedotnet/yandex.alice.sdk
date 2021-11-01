namespace Yandex.Alice.Sdk.Exceptions
{
    using System;
    using System.Runtime.Serialization;

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

        protected AliceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
