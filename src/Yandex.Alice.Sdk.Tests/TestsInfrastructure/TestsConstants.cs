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
            public static readonly string DialogsImageInfoFilePath = $"{_assetsFolderPath}/DialogsImageInfo.json";
            public const string IconFileName = "icon.png";
            public static readonly string IconFilePath = $"{_assetsFolderPath}/{IconFileName}";
            public const string SoundFileName = "sound.mp3";
            public static readonly string SoundFilePath = $"{_assetsFolderPath}/{SoundFileName}";
        }

        public const string DialogsApiCollectionName = "DialogsApiCollection";

    }
}
