namespace Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;
    using Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests.TestsInfrastructure;
    using Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests.TestsInfrastructure.Fixtures;
    using Yandex.Alice.Sdk.Models.DialogsApi;
    using Yandex.Alice.Sdk.Models.SmartHome;
    using Yandex.Alice.Sdk.Services;

    public class DialogsApiServiceTests : IClassFixture<SmartHomeFixture>
    {
        private readonly IDialogsApiService _dialogsApiService;
        private readonly Guid _smartHomeSkillId;

        public DialogsApiServiceTests(SmartHomeFixture smartHomeFixture)
        {
            _dialogsApiService = smartHomeFixture.Services.GetRequiredService<IDialogsApiService>();
            _smartHomeSkillId = smartHomeFixture.Services.GetRequiredService<AliceSettings>().SmartHomeSkillId;
        }

        [Fact]
        public async Task CallbackState()
        {
            // arrange
            var request = new DialogsCallbackStateRequest
            {
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Payload = new DialogsCallbackStatePayload()
                {
                    UserId = SmartHomeDemoConstants.AliceUserId,
                    Devices = new List<DialogsCallbackStateDevice>()
                    {
                        new DialogsCallbackStateDevice()
                        {
                            Id = SmartHomeDemoConstants.LampDeviceId,
                            Capabilities = new List<SmartHomeDeviceCapabilityState>()
                            {
                                new SmartHomeDeviceOnOffCapabilityState()
                                {
                                    State = new SmartHomeDeviceOnOffCapabilityStateValue()
                                    {
                                        Instance = SmartHomeConstants.OnOffFunction.On,
                                        Value = false,
                                    },
                                },
                            },
                            Properties = new List<SmartHomeDevicePropertyState>()
                            {
                                new SmartHomeDeviceFloatPropertyState()
                                {
                                    State = new SmartHomeDeviceFloatPropertyStateValue()
                                    {
                                        Instance = SmartHomeConstants.FloatFunction.BatteryLevel,
                                        Value = 97,
                                    },
                                },
                            },
                        },
                    },
                },
            };

            // act
            var response = await _dialogsApiService.CallbackStateAsync(_smartHomeSkillId, request);

            // assert
            response.IsSuccess.Should().BeTrue(response.ErrorMessage ?? response.ErrorCode);
            response.Content.RequestId.Should().NotBeNullOrEmpty();
            response.Content.Status.Should().NotBeNullOrEmpty();
            response.Content.ErrorCode.Should().BeNull();
            response.Content.ErrorMessage.Should().BeNull();
        }

        [Fact]
        public async Task CallbackDiscovery()
        {
            // arrange
            var request = new DialogsCallbackDiscoveryRequest
            {
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Payload = new DialogsCallbackDiscoveryPayload()
                {
                    UserId = SmartHomeDemoConstants.AliceUserId,
                },
            };

            // act
            var response = await _dialogsApiService.CallbackDiscoveryAsync(_smartHomeSkillId, request);

            // assert
            response.IsSuccess.Should().BeTrue(response.ErrorMessage ?? response.ErrorCode);
            response.Content.RequestId.Should().NotBeNullOrEmpty();
            response.Content.Status.Should().NotBeNullOrEmpty();
            response.Content.ErrorCode.Should().BeNull();
            response.Content.ErrorMessage.Should().BeNull();
        }
    }
}
