namespace Yandex.Alice.Sdk.Demo.SmartHome.Exceptions;

using System;
using System.Runtime.Serialization;

[Serializable]
public class DeviceNotFoundException : Exception
{
    public DeviceNotFoundException()
    {
    }

    protected DeviceNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}