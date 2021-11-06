namespace Yandex.Alice.Sdk.Converters
{
    using System.Globalization;
    using Yandex.Alice.Sdk.Exceptions;
    using Yandex.Alice.Sdk.Models;
    using Yandex.Alice.Sdk.Resources;

    public static class AliceRequestTypeHelper
    {
        public static AliceRequestType ConvertToType(string value)
        {
            switch (value)
            {
                case AliceConstants.RequestType.SimpleUtterance:
                    return AliceRequestType.SimpleUtterance;
                case AliceConstants.RequestType.ButtonPressed:
                    return AliceRequestType.ButtonPressed;
                case AliceConstants.RequestType.GeolocationAllowed:
                    return AliceRequestType.GeolocationAllowed;
                case AliceConstants.RequestType.GeolocationRejected:
                    return AliceRequestType.GeolocationRejected;
                case AliceConstants.RequestType.PurchaseConfirmation:
                    return AliceRequestType.PurchaseConfirmation;
                default:
                    string message = string.Format(CultureInfo.CurrentCulture, Yandex_Alice_Sdk_Resources.Error_Unknown_Request_Type, value);
                    throw new UnknownRequestTypeException(message);
            }
        }

        public static string ConvertToString(AliceRequestType requestType)
        {
            switch (requestType)
            {
                case AliceRequestType.SimpleUtterance:
                    return AliceConstants.RequestType.SimpleUtterance;
                case AliceRequestType.ButtonPressed:
                    return AliceConstants.RequestType.ButtonPressed;
                case AliceRequestType.GeolocationAllowed:
                    return AliceConstants.RequestType.GeolocationAllowed;
                case AliceRequestType.GeolocationRejected:
                    return AliceConstants.RequestType.GeolocationRejected;
                case AliceRequestType.PurchaseConfirmation:
                    return AliceConstants.RequestType.PurchaseConfirmation;
                default:
                    string message = string.Format(CultureInfo.CurrentCulture, Yandex_Alice_Sdk_Resources.Error_Unknown_Request_Type, requestType);
                    throw new UnknownRequestTypeException(message);
            }
        }
    }
}
