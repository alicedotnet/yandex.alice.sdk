namespace Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests.TestsInfrastructure
{
    using System;

    public class AliceSettings
    {
        public Guid SmartHomeSkillId { get; }

        public string IoTApiOAuthToken { get; }

        public AliceSettings(string smartHomeSkillId, string ioTApiOAuthToken)
        {
            SmartHomeSkillId = Guid.Parse(smartHomeSkillId);
            IoTApiOAuthToken = ioTApiOAuthToken;
        }
    }
}
