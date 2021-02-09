using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Tests.Models
{
    public class AliceRequestTypeTests
    {
        [Theory]
        [InlineData("SimpleUtterance", AliceRequestType.SimpleUtterance)]
        [InlineData("ButtonPressed", AliceRequestType.ButtonPressed)]
        [InlineData("Geolocation.Allowed", AliceRequestType.GeolocationAllowed)]
        [InlineData("Geolocation.Rejected", AliceRequestType.GeolocationRejected)]
        public void DeserializeJson_TestRequestType_SuccessfullyConverted(string literal, AliceRequestType type)
        {
            string requestJson = $"{{ \"type\": \"{literal}\" }}";
            var request = JsonSerializer.Deserialize<AliceRequestModel<object>>(requestJson);
            Assert.Equal(type, request.Type);
        }
    }
}
