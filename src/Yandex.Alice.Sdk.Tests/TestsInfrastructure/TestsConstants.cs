using System;
using System.Collections.Generic;
using System.Text;

namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure
{
    static class TestsConstants
    {
        public static class Assets
        {
            private const string _assetsFolderPath = "TestsInfrastructure/Assets";
            public static readonly string AliceRequestFilePath = $"{_assetsFolderPath}/AliceRequest.json";
            public static readonly string AliceResponseFilePath = $"{_assetsFolderPath}/AliceResponse.json";
            public static readonly string AliceImageResponseFilePath = $"{_assetsFolderPath}/AliceImageResponse.json";
            public static readonly string AliceGalleryResponseFilePath = $"{_assetsFolderPath}/AliceGalleryResponse.json";
        }
    }
}
