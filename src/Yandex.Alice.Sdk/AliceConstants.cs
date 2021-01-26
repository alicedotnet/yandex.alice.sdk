using System;
using System.Collections.Generic;
using System.Text;

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
        }

        public static class AliceCardTypeValues
        {
            public const string BigImage = "BigImage";
            public const string ItemsList = "ItemsList";
        }
    }
}
