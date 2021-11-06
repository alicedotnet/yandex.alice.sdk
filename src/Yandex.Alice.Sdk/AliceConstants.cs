namespace Yandex.Alice.Sdk
{
    public static class AliceConstants
    {
        public const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";

        public static class AliceEntityModelFields
        {
            public const string Type = "type";
        }

        public static class AliceEntityTypeValues
        {
            public const string DateTime = "YANDEX.DATETIME";
            public const string Fio = "YANDEX.FIO";
            public const string Geo = "YANDEX.GEO";
            public const string Number = "YANDEX.NUMBER";
            public const string String = "YANDEX.STRING";
        }

        public static class AliceIntents
        {
            public const string Confirm = "YANDEX.CONFIRM";
            public const string Reject = "YANDEX.REJECT";
            public const string Help = "YANDEX.HELP";
            public const string Repeat = "YANDEX.REPEAT";
            public const string WhatCanYouDo = "YANDEX.WHAT_CAN_YOU_DO";
        }

        public static class AliceCardTypeValues
        {
            public const string BigImage = "BigImage";
            public const string ItemsList = "ItemsList";
        }

        public static class Currency
        {
            public const string Rub = "RUB";
        }

        public static class PurchaseType
        {
            public const string Buy = "BUY";
        }

        public static class RequestType
        {
            public const string SimpleUtterance = "SimpleUtterance";
            public const string ButtonPressed = "ButtonPressed";
            public const string GeolocationAllowed = "Geolocation.Allowed";
            public const string GeolocationRejected = "Geolocation.Rejected";
            public const string PurchaseConfirmation = "Purchase.Confirmation";
        }

        public static class NdsType
        {
            public const string Nds20 = "nds_20";
            public const string Nds10 = "nds_10";
            public const string Nds0 = "nds_0";
            public const string NdsNone = "nds_none";
        }
    }
}
