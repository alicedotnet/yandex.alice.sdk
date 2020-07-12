using System;
using System.Collections.Generic;
using System.Text;

namespace Yandex.Alice.Sdk.Models
{
    public enum AliceEntityType
    {
        Unknown,
        DATETIME,
        FIO,
        GEO,
        NUMBER,
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "<Pending>")]
        STRING
    }
}
