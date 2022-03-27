namespace Yandex.Alice.Sdk.Tests.Models;

using System.IO;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Yandex.Alice.Sdk.Models;
using Yandex.Alice.Sdk.Tests.TestsInfrastructure;
using Yandex.Alice.Sdk.Tests.TestsInfrastructure.Wrappers;

public class AliceResponseTests : BaseTests
{
    public AliceResponseTests(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper)
    {
    }

    [Fact]
    public void AliceResponse_KeepSession_HasSession()
    {
        var aliceRequest = new AliceRequest<object, TestSession, object>
        {
            State = new AliceStateModel<TestSession, object>
            {
                Session = new TestSession
                {
                    TestProperty = 1,
                },
            },
        };
        var aliceResponse = new AliceResponse<TestSession, object>(aliceRequest, string.Empty);
        Assert.NotNull(aliceResponse.SessionState);
        Assert.Equal(aliceRequest.State.Session.TestProperty, aliceResponse.SessionState.TestProperty);
    }

    [Fact]
    public void AliceResponse()
    {
        // arrange
        var json = File.ReadAllText(TestsConstants.Assets.AliceResponseFilePath);

        // act
        var aliceResponse = JsonSerializer.Deserialize<AliceResponseWrapper>(json);

        // assert
        aliceResponse.Should().NotBeNull();
        aliceResponse.Version.Should().NotBeNullOrEmpty();
        aliceResponse.SessionState.Should().NotBeNull();
        aliceResponse.UserStateUpdate.Should().NotBeNull();
        aliceResponse.Response.Should().NotBeNull();
        aliceResponse.Response.Text.Should().NotBeNullOrEmpty();
        aliceResponse.Response.Tts.Should().NotBeNullOrEmpty();
        aliceResponse.Response.EndSession.Should().BeTrue();
        aliceResponse.Response.Directives.Should().NotBeNull();
        aliceResponse.Response.Directives.RequestGeolocation.Should().NotBeNull();

        aliceResponse.Response.Directives.StartPurchase.Should().NotBeNull();
        aliceResponse.Response.Directives.StartPurchase.PurchaseRequestId.Should().NotBeNullOrEmpty()
            .And.Be("d432de19be8347d09f656d9fe966e2f9");
        aliceResponse.Response.Directives.StartPurchase.ImageUrl.Should().NotBeNull()
            .And.Be("http://url_to_image_purchase.png/");
        aliceResponse.Response.Directives.StartPurchase.Caption.Should().NotBeNullOrEmpty()
            .And.Be("caption");
        aliceResponse.Response.Directives.StartPurchase.Description.Should().NotBeNullOrEmpty()
            .And.Be("description");
        aliceResponse.Response.Directives.StartPurchase.Currency.Should().NotBeNullOrEmpty()
            .And.Be(AliceConstants.Currency.Rub);
        aliceResponse.Response.Directives.StartPurchase.Type.Should().NotBeNullOrEmpty()
            .And.Be(AliceConstants.PurchaseType.Buy);
        aliceResponse.Response.Directives.StartPurchase.Payload.Should().NotBeNull();
        aliceResponse.Response.Directives.StartPurchase.MerchantKey.Should().NotBeNullOrEmpty()
            .And.Be("d1112abf-27d2-4005-8b47-6861555715d3");
        aliceResponse.Response.Directives.StartPurchase.TestPayment.Should().BeTrue();
        aliceResponse.Response.Directives.StartPurchase.Products.Should().NotBeNullOrEmpty();

        var product = aliceResponse.Response.Directives.StartPurchase.Products.First();
        product.ProductId.Should().NotBeNullOrEmpty()
            .And.Be("5e4cf57a-8497-11ea-bc55-0242ac130209");
        product.Title.Should().NotBeNullOrEmpty()
            .And.Be("title 1");
        product.UserPrice.Should().NotBeNullOrEmpty()
            .And.Be("120");
        product.Price.Should().NotBeNullOrEmpty()
            .And.Be("110");
        product.NdsType.Should().NotBeNullOrEmpty()
            .And.Be(AliceConstants.NdsType.Nds20);
        product.Quantity.Should().NotBeNullOrEmpty()
            .And.Be("2");

        aliceResponse.Response.Directives.ConfirmPurchase.Should().NotBeNull();

        aliceResponse.Response.Buttons.Should().NotBeNullOrEmpty()
            .And.OnlyContain(x => !string.IsNullOrEmpty(x.Title))
            .And.OnlyContain(x => x.Payload != null)
            .And.OnlyContain(x => x.Url != null)
            .And.OnlyContain(x => x.Hide);

        aliceResponse.Analytics.Should().NotBeNull();
        aliceResponse.Analytics.Events.Should().NotBeNullOrEmpty()
            .And.OnlyContain(x => !string.IsNullOrEmpty(x.Name))
            .And.OnlyContain(x => x.Value != null);
        var aliceEvent = aliceResponse.Analytics.Events.First();
        aliceEvent.Name.Should().Be("custom event");
        ((JsonElement)aliceEvent.Value).GetString().Should().Be("value");

        WritePrettyJson(aliceResponse);
    }

    [Fact]
    public void AliceResponse_WithAnalyticsEventOnNullAnalyticsObject_ShouldCreateObjectAndAddEvent()
    {
        // arrange
        var response = new AliceResponse(new AliceRequest(), string.Empty);
        const string eventName = "event";
        const string eventValue = "value";

        // act
        response = response.WithAnalyticsEvent(eventName, eventValue);

        // assert
        response.Analytics.Should().NotBeNull();
        response.Analytics.Events.Should().NotBeNullOrEmpty()
            .And.OnlyContain(x => x.Name == eventName)
            .And.OnlyContain(x => Equals(x.Value, eventValue));
    }

    [Fact]
    public void AliceImageResponse()
    {
        var json = File.ReadAllText(TestsConstants.Assets.AliceImageResponseFilePath);
        var aliceResponse = JsonSerializer.Deserialize<AliceImageResponseWrapper>(json);
        Assert.NotNull(aliceResponse);
        Assert.NotEmpty(aliceResponse.Version);
        Assert.NotNull(aliceResponse.SessionState);
        Assert.NotNull(aliceResponse.UserStateUpdate);
        Assert.NotNull(aliceResponse.Response);
        Assert.NotEmpty(aliceResponse.Response.Text);
        Assert.NotEmpty(aliceResponse.Response.Tts);
        Assert.NotNull(aliceResponse.Response.Card);
        Assert.Equal(AliceCardType.BigImage, aliceResponse.Response.Card.Type);
        Assert.NotEmpty(aliceResponse.Response.Card.ImageId);
        Assert.NotEmpty(aliceResponse.Response.Card.Title);
        Assert.NotEmpty(aliceResponse.Response.Card.Description);
        Assert.NotNull(aliceResponse.Response.Card.Button);
        Assert.NotEmpty(aliceResponse.Response.Card.Button.Text);
        Assert.NotNull(aliceResponse.Response.Card.Button.Url);
        Assert.NotNull(aliceResponse.Response.Card.Button.Payload);
        Assert.True(aliceResponse.Response.EndSession);
        Assert.NotNull(aliceResponse.Response.Buttons);
        Assert.NotEmpty(aliceResponse.Response.Buttons);
        foreach (var button in aliceResponse.Response.Buttons)
        {
            Assert.NotEmpty(button.Title);
            Assert.NotNull(button.Payload);
            Assert.NotNull(button.Url);
            Assert.True(button.Hide);
        }

        WritePrettyJson(aliceResponse);
    }

    [Fact]
    public void AliceGalleryResponse()
    {
        var json = File.ReadAllText(TestsConstants.Assets.AliceGalleryResponseFilePath);
        var aliceResponse = JsonSerializer.Deserialize<AliceGalleryResponseWrapper>(json);
        Assert.NotNull(aliceResponse);
        Assert.NotEmpty(aliceResponse.Version);
        Assert.NotNull(aliceResponse.SessionState);
        Assert.NotNull(aliceResponse.UserStateUpdate);
        Assert.NotNull(aliceResponse.Response);
        Assert.NotEmpty(aliceResponse.Response.Text);
        Assert.NotEmpty(aliceResponse.Response.Tts);
        Assert.NotNull(aliceResponse.Response.Card);
        Assert.Equal(AliceCardType.ItemsList, aliceResponse.Response.Card.Type);
        Assert.NotNull(aliceResponse.Response.Card.Header);
        Assert.NotEmpty(aliceResponse.Response.Card.Header.Text);
        Assert.NotNull(aliceResponse.Response.Card.Items);
        Assert.NotEmpty(aliceResponse.Response.Card.Items);
        foreach (var item in aliceResponse.Response.Card.Items)
        {
            Assert.NotEmpty(item.ImageId);
            Assert.NotEmpty(item.Title);
            Assert.NotEmpty(item.Description);
            Assert.NotNull(item.Button);
            Assert.NotEmpty(item.Button.Text);
            Assert.NotNull(item.Button.Url);
            Assert.NotNull(item.Button.Payload);
        }

        Assert.NotNull(aliceResponse.Response.Card.Footer);
        Assert.NotEmpty(aliceResponse.Response.Card.Footer.Text);
        Assert.NotNull(aliceResponse.Response.Card.Footer.Button);
        Assert.NotEmpty(aliceResponse.Response.Card.Footer.Button.Text);
        Assert.NotNull(aliceResponse.Response.Card.Footer.Button.Url);
        Assert.NotNull(aliceResponse.Response.Card.Footer.Button.Payload);
        Assert.True(aliceResponse.Response.EndSession);
        Assert.NotNull(aliceResponse.Response.Buttons);
        Assert.NotEmpty(aliceResponse.Response.Buttons);
        foreach (var button in aliceResponse.Response.Buttons)
        {
            Assert.NotEmpty(button.Title);
            Assert.NotNull(button.Payload);
            Assert.NotNull(button.Url);
            Assert.True(button.Hide);
        }

        WritePrettyJson(aliceResponse);
    }

    [Fact]
    public void Alice_GetResponseFromPing_Success()
    {
        var requestJson = File.ReadAllText(TestsConstants.Assets.AliceRequestPingFilePath);
        var aliceRequest = JsonSerializer.Deserialize<AliceRequest<object, object, object>>(requestJson);
        var response = new AliceResponse(aliceRequest, string.Empty);
        Assert.NotNull(response);
    }

    private class TestSession
    {
        public int TestProperty { get; init; }
    }
}