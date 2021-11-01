namespace Yandex.Alice.Sdk.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
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

        protected UnknownRequestTypeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
