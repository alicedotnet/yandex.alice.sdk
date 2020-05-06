using System;
using System.Collections.Generic;
using System.Text;

namespace Yandex.Alice.Sdk
{
    static class Constants
    {
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
        }

        public static class AliceCardTypeValues
        {
            public const string BigImage = "BigImage";
            public const string ItemsList = "ItemsList";
        }
    }
}
