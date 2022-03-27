namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure;

internal static class TestsConstants
{
    public const string DialogsApiCollectionName = "DialogsApiCollection";
    public const string InvalidCredentialsMessage = "Forbidden (no credentials)";

    public static class Assets
    {
        public const string IconFileName = "icon.png";
        public const string SoundFileName = "sound.mp3";
        public const string AliceRequestFilePath = $"{_assetsFolderPath}/AliceRequest.json";
        public const string AliceRequestPingFilePath = $"{_assetsFolderPath}/AliceRequest_Ping.json";
        public const string AliceRequestPurchaseConfirmationFilePath = $"{_assetsFolderPath}/AliceRequest_PurchaseConfirmation.json";
        public const string AliceResponseFilePath = $"{_assetsFolderPath}/AliceResponse.json";
        public const string AliceImageResponseFilePath = $"{_assetsFolderPath}/AliceImageResponse.json";
        public const string AliceGalleryResponseFilePath = $"{_assetsFolderPath}/AliceGalleryResponse.json";
        public const string ColorSettingStatesFilePath = $"{_assetsFolderPath}/ColorSettingStates.json";
        public const string DialogsImageInfoFilePath = $"{_assetsFolderPath}/DialogsImageInfo.json";
        public const string IoTUserInfoFilePath = $"{_assetsFolderPath}/IoTUserInfo.json";
        public const string IconFilePath = $"{_assetsFolderPath}/{IconFileName}";
        public const string SoundFilePath = $"{_assetsFolderPath}/{SoundFileName}";
        private const string _assetsFolderPath = "TestsInfrastructure/Assets";
    }
}