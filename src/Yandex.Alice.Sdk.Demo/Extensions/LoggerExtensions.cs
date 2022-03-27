namespace Yandex.Alice.Sdk.Demo.Extensions;

using System;
using Microsoft.Extensions.Logging;
using Yandex.Alice.Sdk.Demo.Models;

public static class LoggerExtensions
{
    private static readonly Action<ILogger, Exception> _unexpectedError = LoggerMessage.Define(
        LogLevel.Error,
        new EventId((int)DemoEventId.UnexpectedError),
        string.Empty);

    private static readonly Action<ILogger, string, Exception> _unexpectedRequestError = LoggerMessage.Define<string>(
        LogLevel.Error,
        new EventId((int)DemoEventId.UnexpectedError),
        "The following request produced exception: {RequestText}");

    public static void UnexpectedError(this ILogger logger, Exception exception)
    {
        _unexpectedError(logger, exception);
    }

    public static void UnexpectedRequestError(this ILogger logger, Exception exception, string requestText)
    {
        _unexpectedRequestError(logger, requestText, exception);
    }
}