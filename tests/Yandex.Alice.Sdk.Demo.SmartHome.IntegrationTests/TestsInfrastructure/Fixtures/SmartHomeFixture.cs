namespace Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests.TestsInfrastructure.Fixtures;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using FluentAssertions;
using HtmlAgilityPack;
using IdentityServer4;
using JetBrains.Annotations;
using Xunit;

[UsedImplicitly]
public class SmartHomeFixture : IAsyncLifetime
{
    public HttpClient Client { get; }

    public TestToken Token { get; private set; }

    public IServiceProvider Services { get; }

    public SmartHomeFixture()
    {
        var factory = new WebApplicationFactoryExtended();
        Services = factory.Services;
        Client = factory.CreateClient();
    }

    public async Task InitializeAsync()
    {
        const string clientId = "alice";
        var scopes = string.Join(' ', IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.LocalApi.ScopeName, IdentityServerConstants.StandardScopes.OfflineAccess);
        const string redirectUri = "https://social.yandex.net/broker/redirect";

        // getting url to login page on IdentityServer
        var url = $"/connect/authorize?client_id={clientId}&scope={scopes}&response_type=code&redirect_uri={redirectUri}";
        var response = await Client.GetAsync(url);

        var content = await response.Content.ReadAsStringAsync();
        response.StatusCode.Should().Be(HttpStatusCode.OK, content);
        content.Should().NotContain("error");

        // get __RequestVerificationToken
        var doc = new HtmlDocument();
        doc.LoadHtml(content);
        const string xpath = "//input[@name='__RequestVerificationToken']";
        var node = doc.DocumentNode.SelectSingleNode(xpath);
        node.Should().NotBeNull();
        var requestVerificationToken = node.GetAttributeValue<string>("value", null);
        requestVerificationToken.Should().NotBeNull();

        // trying to login on IdentityServer
        var parameters = new Dictionary<string, string>
        {
            { "Username", "bob" },
            { "Password", "bob" },
            { "button", "login" },
            { "__RequestVerificationToken", requestVerificationToken },
        };
        var payload = new FormUrlEncodedContent(parameters);

        var loginUri = response.RequestMessage.RequestUri;
        var loginResponse = await Client.PostAsync(loginUri, payload);
        var loginContext = await loginResponse.Content.ReadAsStringAsync();
        loginResponse.StatusCode.Should().Be(HttpStatusCode.NotFound, loginContext);

        // on successful login it will return redirect. redirect url will have necessary code and scopes
        var query = HttpUtility.ParseQueryString(loginResponse.RequestMessage.RequestUri.Query);
        var code = query["code"];
        code.Should().NotBeNullOrEmpty();
        var scope = query["scope"];
        scope.Should().NotBeNullOrEmpty();

        // sending request to get token
        var getTokenParameters = new Dictionary<string, string>
        {
            { "grant_type", "authorization_code" },
            { "scope", scope },
            { "client_id", clientId },
            { "code", code },
            { "redirect_uri", redirectUri },
        };
        var getTokenPayload = new FormUrlEncodedContent(getTokenParameters);
        var getTokenResponse = await Client.PostAsync("/connect/token", getTokenPayload);
        var getTokenContent = await getTokenResponse.Content.ReadAsStringAsync();
        getTokenResponse.StatusCode.Should().Be(HttpStatusCode.OK, getTokenContent);

        var token = JsonSerializer.Deserialize<TestToken>(getTokenContent);
        token.Should().NotBeNull();
        token.AccessToken.Should().NotBeNullOrEmpty();

        Token = token;
    }

    public Task DisposeAsync() => Task.CompletedTask;
}