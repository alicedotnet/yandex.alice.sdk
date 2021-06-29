namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure
{
    internal static class TestsConstants
    {
        public const string DialogsApiCollectionName = "DialogsApiCollection";

        public static class Assets
        {
            public const string IconFileName = "icon.png";
            public const string SoundFileName = "sound.mp3";
            public static readonly string AliceRequestFilePath = $"{_assetsFolderPath}/AliceRequest.json";
            public static readonly string AliceRequestPingFilePath = $"{_assetsFolderPath}/AliceRequest_Ping.json";
            public static readonly string AliceResponseFilePath = $"{_assetsFolderPath}/AliceResponse.json";
            public static readonly string AliceImageResponseFilePath = $"{_assetsFolderPath}/AliceImageResponse.json";
            public static readonly string AliceGalleryResponseFilePath = $"{_assetsFolderPath}/AliceGalleryResponse.json";
            public static readonly string DialogsImageInfoFilePath = $"{_assetsFolderPath}/DialogsImageInfo.json";
            public static readonly string IconFilePath = $"{_assetsFolderPath}/{IconFileName}";
            public static readonly string SoundFilePath = $"{_assetsFolderPath}/{SoundFileName}";
            private const string _assetsFolderPath = "TestsInfrastructure/Assets";
        }
    }
}
