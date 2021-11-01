namespace Yandex.Alice.Sdk.Demo.SmartHome.Models
{
    using Microsoft.AspNetCore.Mvc;

    public class SmartHomeRequestHeaders
    {
        [FromHeader(Name = "X-Request-Id")]
        public string RequestId { get; set; }
    }
}
