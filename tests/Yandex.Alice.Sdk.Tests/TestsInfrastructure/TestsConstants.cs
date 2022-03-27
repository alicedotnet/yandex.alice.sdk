namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure
{
    internal static class TestsConstants
    {
        public const string DialogsApiCollectionName = "DialogsApiCollection";
        public const string InvalidCredentialsMessage = "Forbidden (no credentials)";

        public static class Assets
        {
            public const string IconFileName = "icon.png";
            public const string SoundFileName = "sound.mp3";
            public static readonly string AliceRequestFilePath = $"{_assetsFolderPath}/AliceRequest.json";
            public static readonly string AliceRequestPingFilePath = $"{_assetsFolderPath}/AliceRequest_Ping.json";
            public static readonly string AliceRequestPurchaseConfirmationFilePath = $"{_assetsFolderPath}/AliceRequest_PurchaseConfirmation.json";
            public static readonly string AliceResponseFilePath = $"{_assetsFolderPath}/AliceResponse.json";
            public static readonly string AliceImageResponseFilePath = $"{_assetsFolderPath}/AliceImageResponse.json";
            public static readonly string AliceGalleryResponseFilePath = $"{_assetsFolderPath}/AliceGalleryResponse.json";
            public static readonly string ColorSettingStatesFilePath = $"{_assetsFolderPath}/ColorSettingStates.json";
            public static readonly string DialogsImageInfoFilePath = $"{_assetsFolderPath}/DialogsImageInfo.json";
            public static readonly string IoTUserInfoFilePath = $"{_assetsFolderPath}/IoTUserInfo.json";
            public static readonly string IconFilePath = $"{_assetsFolderPath}/{IconFileName}";
            public static readonly string SoundFilePath = $"{_assetsFolderPath}/{SoundFileName}";
            private const string _assetsFolderPath = "TestsInfrastructure/Assets";
        }
    }
}
