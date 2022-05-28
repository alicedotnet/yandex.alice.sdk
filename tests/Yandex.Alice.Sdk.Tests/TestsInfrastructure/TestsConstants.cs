namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure;

internal static class TestsConstants
{
    public static class Assets
    {
        public const string AliceRequestFilePath = $"{_assetsFolderPath}/AliceRequest.json";
        public const string AliceRequestPingFilePath = $"{_assetsFolderPath}/AliceRequest_Ping.json";
        public const string AliceRequestPurchaseConfirmationFilePath = $"{_assetsFolderPath}/AliceRequest_PurchaseConfirmation.json";
        public const string AliceResponseFilePath = $"{_assetsFolderPath}/AliceResponse.json";
        public const string AliceImageResponseFilePath = $"{_assetsFolderPath}/AliceImageResponse.json";
        public const string AliceGalleryResponseFilePath = $"{_assetsFolderPath}/AliceGalleryResponse.json";
        public const string ColorSettingStatesFilePath = $"{_assetsFolderPath}/ColorSettingStates.json";
        public const string DialogsImageInfoFilePath = $"{_assetsFolderPath}/DialogsImageInfo.json";
        public const string IoTUserInfoFilePath = $"{_assetsFolderPath}/IoTUserInfo.json";
        private const string _assetsFolderPath = "TestsInfrastructure/Assets";
    }
}