namespace Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;
    using Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests.TestsInfrastructure;
    using Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests.TestsInfrastructure.Fixtures;
    using Yandex.Alice.Sdk.Models.IoTApi;
    using Yandex.Alice.Sdk.Models.SmartHome;
    using Yandex.Alice.Sdk.Services;

    public class IoTApiServiceTests : IClassFixture<SmartHomeFixture>
    {
        private readonly IIoTApiService _ioTApiService;
        private readonly string _authToken;

        public IoTApiServiceTests(SmartHomeFixture smartHomeFixture)
        {
            _ioTApiService = smartHomeFixture.Services.GetRequiredService<IIoTApiService>();
            _authToken = smartHomeFixture.Services.GetRequiredService<AliceSettings>().IoTApiOAuthToken;
        }

        [Fact]
        public void GetUserInfo_NoAuthToken_ShouldThrowException()
        {
            // arrange
            // act
            Func<Task> act = async () => await _ioTApiService.GetUserInfoAsync(null);

            // assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task GetUserInfo_InvalidAuthToken_ShouldBeError()
        {
            // arrange
            // act
            var response = await _ioTApiService.GetUserInfoAsync("invalid_token");

            // assert
            response.IsSuccess.Should().BeFalse();
            response.Content.Should().BeNull();
            response.ErrorMessage.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetUserInfo_ValidToken_ShouldReturnUserInfo()
        {
            // arrange
            // act
            var response = await _ioTApiService.GetUserInfoAsync(_authToken);

            // assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue(response.ErrorMessage);
            response.Content.RequestId.Should().NotBeNullOrEmpty();
            response.Content.Status.Should().Be(SmartHomeConstants.Status.Ok);
            response.Content.Rooms.Should().NotBeNullOrEmpty()
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Id))
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Name))
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.HouseholdId))
                .And.OnlyContain(x => x.Devices != null && x.Devices.Any())
                .And.OnlyContain(x => x.Devices.All(d => !string.IsNullOrEmpty(d)));
            response.Content.Groups.Should().NotBeNullOrEmpty()
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Id))
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Name))
                .And.OnlyContain(x => x.Aliases != null)
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.HouseholdId))
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Type))
                .And.OnlyContain(x => x.Devices != null && x.Devices.Any())
                .And.OnlyContain(x => x.Devices.All(d => !string.IsNullOrEmpty(d)))
                .And.OnlyContain(x => x.Capabilities != null && x.Capabilities.Any())
                .And.OnlyContain(x => x.Capabilities.All(c => c.Retrievable))
                .And.OnlyContain(x => x.Capabilities.All(c => !string.IsNullOrEmpty(c.Type)))
                .And.OnlyContain(x => x.Capabilities.Any(c => c is IoTGroupOnOffCapability))
                .And.OnlyContain(x => x.Capabilities
                    .Where(c => c is IoTGroupOnOffCapability)
                    .Any(c => (c as IoTGroupOnOffCapability).State != null))
                .And.OnlyContain(x => x.Capabilities
                    .Where(c => c is IoTGroupOnOffCapability)
                    .Any(c => (c as IoTGroupOnOffCapability).Parameters != null));
            response.Content.Devices.Should().NotBeNullOrEmpty()
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Id))
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Name))
                .And.OnlyContain(x => x.Aliases != null)
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Type))
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.ExternalId))
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.SkillId))
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.HouseholdId))
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Room))
                .And.OnlyContain(x => x.Groups != null)
                .And.OnlyContain(x => x.Capabilities != null)
                .And.OnlyContain(x => x.Properties != null);
            response.Content.Scenarios.Should().NotBeNullOrEmpty()
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Id))
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Name))
                .And.OnlyContain(x => x.IsActive);
            response.Content.Households.Should().NotBeNullOrEmpty()
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Id))
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Name));
        }

        [Fact]
        public async Task GetDevice_NoDeviceId_ShouldBeError()
        {
            // arrange
            // act
            Func<Task> act = () => _ioTApiService.GetDeviceAsync(_authToken, null);

            // assert
            await act.Should().ThrowExactlyAsync<ArgumentException>();
        }

        [Fact]
        public async Task GetDevice_InvalidDeviceId_ShouldBeError()
        {
            // arrange
            // act
            var response = await _ioTApiService.GetDeviceAsync(_authToken, "invalid");

            // assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.ErrorMessage.Should().BeNull();
            response.Content.Should().NotBeNull();
            response.Content.Status.Should().Be(SmartHomeConstants.Status.Error);
            response.Content.RequestId.Should().NotBeNullOrEmpty();
            response.Content.Message.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetDevice_ValidDeviceId_ShouldReturnDeviceInfo()
        {
            // arrange
            var userInfo = await _ioTApiService.GetUserInfoAsync(_authToken);
            var deviceId = userInfo.Content.Devices.First(x => x.Type == SmartHomeConstants.Devices.Types.Light).Id;

            // act
            var response = await _ioTApiService.GetDeviceAsync(_authToken, deviceId);

            // assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.ErrorMessage.Should().BeNull();
            response.Content.Should().NotBeNull();
            response.Content.Status.Should().Be(SmartHomeConstants.Status.Ok);
            response.Content.RequestId.Should().NotBeNullOrEmpty();
            response.Content.Message.Should().BeNullOrEmpty();
            response.Content.Id.Should().NotBeNullOrEmpty()
                .And.Be(deviceId);
            response.Content.Name.Should().NotBeNullOrEmpty();
            response.Content.Aliases.Should().NotBeNull();
            response.Content.Type.Should().NotBeNullOrEmpty();
            response.Content.State.Should().NotBeNullOrEmpty();
            response.Content.Groups.Should().NotBeNullOrEmpty();
            response.Content.Room.Should().NotBeNullOrEmpty();
            response.Content.ExternalId.Should().NotBeNullOrEmpty();
            response.Content.SkillId.Should().NotBeNullOrEmpty();
            response.Content.Capabilities.Should().NotBeNullOrEmpty();
            response.Content.Properties.Should().NotBeNullOrEmpty()
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Type))
                .And.OnlyContain(x => x is IoTDeviceFloatProperty)
                .And.OnlyContain(x => (x as IoTDeviceFloatProperty).State != null)
                .And.OnlyContain(x => !string.IsNullOrEmpty((x as IoTDeviceFloatProperty).State.Instance))
                .And.OnlyContain(x => (x as IoTDeviceFloatProperty).State.Value > 0)
                .And.OnlyContain(x => (x as IoTDeviceFloatProperty).Parameters != null)
                .And.OnlyContain(x => !string.IsNullOrEmpty((x as IoTDeviceFloatProperty).Parameters.Instance))
                .And.OnlyContain(x => !string.IsNullOrEmpty((x as IoTDeviceFloatProperty).Parameters.Unit));
        }

        [Fact]
        public async Task ManageDevices_NullRequest_ShouldThrow()
        {
            // arrange
            IoTManageDevicesRequest request = null;

            // act
            Func<Task> act = async () => await _ioTApiService.ManageDevicesAsync(_authToken, request);

            // assert
            await act.Should().ThrowExactlyAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task ManageDevices_InvalidDeviceId_ShouldReturnNotFound()
        {
            // arrange
            var request = new IoTManageDevicesRequest()
            {
                Devices = new List<IoTManageDeviceRequest>()
                {
                    new IoTManageDeviceRequest()
                    {
                        Id = "unknown",
                    },
                },
            };

            // act
            var response = await _ioTApiService.ManageDevicesAsync(_authToken, request);

            // assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.Content.RequestId.Should().NotBeNullOrEmpty();
            response.Content.Status.Should().Be(SmartHomeConstants.Status.Error);
            response.Content.Message.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task ManageDevice_ValidDeviceId_ShouldChangeStatus()
        {
            // arrange
            var userInfo = await _ioTApiService.GetUserInfoAsync(_authToken);
            var deviceId = userInfo.Content.Devices.First(x => x.Type == SmartHomeConstants.Devices.Types.Light).Id;

            var request = new IoTManageDevicesRequest()
            {
                Devices = new List<IoTManageDeviceRequest>()
                {
                    new IoTManageDeviceRequest()
                    {
                        Id = deviceId,
                        Actions = new List<SmartHomeDeviceCapabilityState>()
                        {
                            new SmartHomeDeviceToggleCapabilityState()
                            {
                                State = new SmartHomeDeviceToggleCapabilityStateValue()
                                {
                                    Instance = SmartHomeConstants.ToggleFunction.Mute,
                                    Value = true,
                                },
                            },
                        },
                    },
                },
            };

            // act
            var response = await _ioTApiService.ManageDevicesAsync(_authToken, request);

            // assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.ErrorMessage.Should().BeNull();
            response.Content.Should().NotBeNull();
            response.Content.Status.Should().Be(SmartHomeConstants.Status.Ok);
            response.Content.RequestId.Should().NotBeNullOrEmpty();
            response.Content.Message.Should().BeNullOrEmpty();
            response.Content.Devices.Should().NotBeNullOrEmpty()
                .And.OnlyContain(x => x.Id == deviceId);

            var device = response.Content.Devices.First();
            device.Capabilities.Should().NotBeNullOrEmpty()
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Type))
                .And.OnlyContain(x => x.State != null)
                .And.OnlyContain(x => x.State.Instance == SmartHomeConstants.ToggleFunction.Mute)
                .And.OnlyContain(x => x.State.ActionResult != null)
                .And.OnlyContain(x => x.State.ActionResult.Status == SmartHomeConstants.ActionResult.Done);
        }

        [Fact]
        public async Task GetGroup_NullGroupId_ShouldThrow()
        {
            // arrange
            string groupId = null;

            // act
            Func<Task> act = async () => await _ioTApiService.GetGroupAsync(_authToken, groupId);

            // assert
            await act.Should().ThrowExactlyAsync<ArgumentException>();
        }

        [Fact]
        public async Task GetGroup_InvalidGroupId_ShouldReturnNotFound()
        {
            // arrange
            string groupId = "unknown";

            // act
            var response = await _ioTApiService.GetGroupAsync(_authToken, groupId);

            // assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.Content.RequestId.Should().NotBeNullOrEmpty();
            response.Content.Status.Should().Be(SmartHomeConstants.Status.Error);
            response.Content.Message.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetGroup_ValidGroupId_ShouldReturnGroup()
        {
            // arrange
            var userInfo = await _ioTApiService.GetUserInfoAsync(_authToken);
            var groupId = userInfo.Content.Groups.First().Id;

            // act
            var response = await _ioTApiService.GetGroupAsync(_authToken, groupId);

            // assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.ErrorMessage.Should().BeNull();
            response.Content.Should().NotBeNull();
            response.Content.Status.Should().Be(SmartHomeConstants.Status.Ok);
            response.Content.RequestId.Should().NotBeNullOrEmpty();
            response.Content.Message.Should().BeNullOrEmpty();
            response.Content.Id.Should().NotBeNullOrEmpty();
            response.Content.Name.Should().NotBeNullOrEmpty();
            response.Content.Aliases.Should().NotBeNull();
            response.Content.Type.Should().NotBeNullOrEmpty();
            response.Content.State.Should().NotBeNullOrEmpty()
                .And.Be(SmartHomeConstants.GroupState.Online);
            response.Content.Capabilities.Should().NotBeNullOrEmpty();
            response.Content.Devices.Should().NotBeNullOrEmpty()
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Id))
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Name))
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Type));
        }

        [Fact]
        public async Task ManageGroup_NullGroupId_ShouldThrow()
        {
            // arrange
            var request = new IoTManageGroupRequest();
            string groupId = null;

            // act
            Func<Task> act = async () => await _ioTApiService.ManageGroupAsync(_authToken, groupId, request);

            // assert
            await act.Should().ThrowExactlyAsync<ArgumentException>();
        }

        [Fact]
        public async Task ManageGroup_NullRequest_ShouldThrow()
        {
            // arrange
            IoTManageGroupRequest request = null;
            string groupId = "unknown";

            // act
            Func<Task> act = async () => await _ioTApiService.ManageGroupAsync(_authToken, groupId, request);

            // assert
            await act.Should().ThrowExactlyAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task ManageGroup_InvalidGroupId_ShouldReturnNotFound()
        {
            // arrange
            var request = new IoTManageGroupRequest();
            string groupId = "unknown";

            // act
            var response = await _ioTApiService.ManageGroupAsync(_authToken, groupId, request);

            // assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.Content.RequestId.Should().NotBeNullOrEmpty();
            response.Content.Status.Should().Be(SmartHomeConstants.Status.Error);
            response.Content.Message.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task ManageGroup_ValidGroupId_ShouldChangeStatus()
        {
            // arrange
            var userInfo = await _ioTApiService.GetUserInfoAsync(_authToken);
            var groupId = userInfo.Content.Groups.First().Id;

            var request = new IoTManageGroupRequest()
            {
                Actions = new List<SmartHomeDeviceCapabilityState>()
                {
                    new SmartHomeDeviceToggleCapabilityState()
                    {
                        State = new SmartHomeDeviceToggleCapabilityStateValue()
                        {
                            Instance = SmartHomeConstants.ToggleFunction.Mute,
                            Value = true,
                        },
                    },
                },
            };

            // act
            var response = await _ioTApiService.ManageGroupAsync(_authToken, groupId, request);

            // assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.ErrorMessage.Should().BeNull();
            response.Content.Should().NotBeNull();
            response.Content.Status.Should().Be(SmartHomeConstants.Status.Ok);
            response.Content.RequestId.Should().NotBeNullOrEmpty();
            response.Content.Message.Should().BeNullOrEmpty();
            response.Content.Devices.Should().NotBeNullOrEmpty();

            var device = response.Content.Devices.First();
            device.Capabilities.Should().NotBeNullOrEmpty()
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.Type))
                .And.OnlyContain(x => x.State != null)
                .And.OnlyContain(x => x.State.Instance == SmartHomeConstants.ToggleFunction.Mute)
                .And.OnlyContain(x => x.State.ActionResult != null)
                .And.OnlyContain(x => x.State.ActionResult.Status == SmartHomeConstants.ActionResult.Done);
        }

        [Fact]
        public async Task ManageScenario_NullScenarioId_ShouldThrow()
        {
            // arrange
            string scenarionId = null;

            // act
            Func<Task> act = async () => await _ioTApiService.ManageScenarioAsync(_authToken, scenarionId);

            // assert
            await act.Should().ThrowExactlyAsync<ArgumentException>();
        }

        [Fact]
        public async Task ManageScenario_InvalidScenarioId_ShouldReturnNotFound()
        {
            // arrange
            string scenarionId = "unknown";

            // act
            var response = await _ioTApiService.ManageScenarioAsync(_authToken, scenarionId);

            // assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.Content.RequestId.Should().NotBeNullOrEmpty();
            response.Content.Status.Should().Be(SmartHomeConstants.Status.Error);
            response.Content.Message.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task ManageScenario_ValidScenarioId_ShouldStartScenario()
        {
            // arrange
            var userInfo = await _ioTApiService.GetUserInfoAsync(_authToken);
            var scenarioId = userInfo.Content.Scenarios.First(x => x.Name == "тест").Id;

            // act
            var response = await _ioTApiService.ManageScenarioAsync(_authToken, scenarioId);

            // assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.ErrorMessage.Should().BeNull();
            response.Content.Should().NotBeNull();
            response.Content.Status.Should().Be(SmartHomeConstants.Status.Ok);
            response.Content.RequestId.Should().NotBeNullOrEmpty();
            response.Content.Message.Should().BeNullOrEmpty();
        }
    }
}
