using System.Collections.Generic;
using System.Threading.Tasks;
using PangeaCyber.Net;
using PangeaCyber.Net.Exceptions;
using PangeaCyber.Net.Redact;
using Xunit;

namespace PangeaCyber.Tests.Integration;

///
public class ITRedactTest
{
    private readonly RedactClient client;
    private readonly TestEnvironment environment = Helper.LoadTestEnvironment("redact", TestEnvironment.LVE);

    ///
    public ITRedactTest()
    {
        var config = Config.FromIntegrationEnvironment(environment);
        client = new RedactClient.Builder(config).Build();
    }

    [Fact]
    public async Task TestRedactText()
    {
        var response = await client.RedactText(new RedactTextRequest("Jenny Jenny... 415-867-5309") { ReturnResult = true });

        Assert.True(response.IsOK);
        Assert.Equal("<PERSON>... <PHONE_NUMBER>", response.Result.RedactedText);
        Assert.Equal(2, response.Result.Count);
        Assert.Null(response.Result.Report);
    }

    [Fact]
    public async Task TestRedactText_2()
    {
        var response = await client.RedactText(new RedactTextRequest("Jenny Jenny... 415-867-5309") { Debug = true, ReturnResult = true });

        Assert.True(response.IsOK);
        Assert.Equal("<PERSON>... <PHONE_NUMBER>", response.Result.RedactedText);
        Assert.Equal(2, response.Result.Count);
        Assert.NotNull(response.Result.Report);
    }

    [Fact]
    public async Task TestRedactText_3()
    {
        var response = await client.RedactText(new RedactTextRequest("Jenny Jenny... 415-867-5309") { Debug = true, ReturnResult = false });

        Assert.True(response.IsOK);
        Assert.Null(response.Result.RedactedText);
        Assert.Equal(2, response.Result.Count);
        Assert.NotNull(response.Result.Report);
    }

    [Fact]
    public async Task TestRedactStructured()
    {
        var data = new Dictionary<string, object>
        {
            { "Name", "Jenny Jenny" },
            { "Phone", "This is its number: 415-867-5309" },
            { "IP", "Its ip is 127.0.0.1"}
        };

        var response = await client.RedactStructured(new RedactStructuredRequest(data) { ReturnResult = true });
        var converted = ((Newtonsoft.Json.Linq.JObject)response.Result.RedactedData).ToObject<Dictionary<string, object>>();

        var expected = new Dictionary<string, object>
        {
            { "Name", "<PERSON>" },
            { "Phone", "This is its number: <PHONE_NUMBER>" },
            { "IP", "Its ip is 127.0.0.1"}
        };

        Assert.True(response.IsOK);
        Assert.Equal(expected, converted);
        Assert.Equal(2, response.Result.Count);
        Assert.Null(response.Result.Report);
    }

    [Fact]
    public async Task TestRedactStructured_2()
    {
        var data = new Dictionary<string, object>
        {
            { "Name", "Jenny Jenny" },
            { "Phone", "This is its number: 415-867-5309" },
            { "IP", "Its ip is 127.0.0.1"}
        };

        var response = await client.RedactStructured(new RedactStructuredRequest(data) { Format = "json", ReturnResult = true });
        var converted = ((Newtonsoft.Json.Linq.JObject)response.Result.RedactedData).ToObject<Dictionary<string, object>>();

        var expected = new Dictionary<string, object>
        {
            { "Name", "<PERSON>" },
            { "Phone", "This is its number: <PHONE_NUMBER>" },
            { "IP", "Its ip is 127.0.0.1"}
        };

        Assert.True(response.IsOK);
        Assert.Equal(expected, converted);
        Assert.Null(response.Result.Report);
    }

    [Fact]
    public async Task TestRedactStructured_3()
    {
        var data = new Dictionary<string, object>
        {
            { "Name", "Jenny Jenny" },
            { "Phone", "This is its number: 415-867-5309" },
            { "IP", "Its ip is 127.0.0.1"}
        };

        var response = await client.RedactStructured(new RedactStructuredRequest(data) { Debug = true, Format = "json", ReturnResult = true });
        var converted = ((Newtonsoft.Json.Linq.JObject)response.Result.RedactedData).ToObject<Dictionary<string, object>>();

        var expected = new Dictionary<string, object>
        {
            { "Name", "<PERSON>" },
            { "Phone", "This is its number: <PHONE_NUMBER>" },
            { "IP", "Its ip is 127.0.0.1"}
        };

        Assert.True(response.IsOK);
        Assert.Equal(expected, converted);
        Assert.NotNull(response.Result.Report);
    }

    [Fact]
    public async Task TestRedactStructured_4()
    {
        var data = new Dictionary<string, object>
        {
            { "Name", "Jenny Jenny" },
            { "Phone", "This is its number: 415-867-5309" },
            { "IP", "Its ip is 127.0.0.1"}
        };

        var response = await client.RedactStructured(new RedactStructuredRequest(data) { Format = "json", Jsonp = ["Phone"], ReturnResult = true });
        var converted = ((Newtonsoft.Json.Linq.JObject)response.Result.RedactedData).ToObject<Dictionary<string, object>>();

        var expected = new Dictionary<string, object>
        {
            { "Name", "Jenny Jenny" },
            { "Phone", "This is its number: <PHONE_NUMBER>" },
            { "IP", "Its ip is 127.0.0.1"}
        };

        Assert.True(response.IsOK);
        Assert.Equal(converted, expected);
        Assert.Equal(1, response.Result.Count);
        Assert.Null(response.Result.Report);
    }

    [Fact]
    public async Task TestRedactStructured_5()
    {
        var data = new Dictionary<string, object>
        {
            { "Name", "Jenny Jenny" },
            { "Phone", "This is its number: 415-867-5309" },
            { "IP", "Its ip is 127.0.0.1" }
        };

        var response = await client.RedactStructured(new RedactStructuredRequest(data) { Format = "json", Rules = ["IP_ADDRESS"], ReturnResult = true });
        var converted = ((Newtonsoft.Json.Linq.JObject)response.Result.RedactedData).ToObject<Dictionary<string, object>>();

        var expected = new Dictionary<string, object>
        {
            { "Name", "Jenny Jenny" },
            { "Phone", "This is its number: 415-867-5309" },
            { "IP", "Its ip is <IP_ADDRESS>" }
        };

        Assert.True(response.IsOK);
        Assert.Equal(expected, converted);
        Assert.Equal(1, response.Result.Count);
        Assert.Null(response.Result.Report);
    }

    [Fact]
    public async Task TestRedactTextUnauthorized()
    {
        Config cfg = Config.FromIntegrationEnvironment(environment);
        cfg.Token = "notarealtoken";
        var fakeClient = new RedactClient.Builder(cfg).Build();
        await Assert.ThrowsAsync<UnauthorizedException>(async () => await fakeClient.RedactText(new RedactTextRequest("Jenny Jenny... 415-867-5309") { ReturnResult = true }));
    }

    [Fact]
    public async Task TestRedactStructuredUnauthorized()
    {
        var data = new Dictionary<string, object>
        {
            { "Name", "Jenny Jenny" },
            { "Phone", "This is its number: 415-867-5309" }
        };

        Config cfg = Config.FromIntegrationEnvironment(environment);
        cfg.Token = "notarealtoken";
        var fakeClient = new RedactClient.Builder(cfg).Build();
        await Assert.ThrowsAsync<UnauthorizedException>(async () => await fakeClient.RedactStructured(new RedactStructuredRequest(data) { ReturnResult = true }));
    }

    [Fact]
    public async Task TestRedactMultiConfig_1()
    {
        var cfg = new Config(Config.GetMultiConfigTestToken(environment)) { Domain = Config.GetTestDomain(environment) };
        var ConfigID = Config.GetConfigID(environment, RedactClient.ServiceName, 1);
        var clientMultiConfig = new RedactClient.Builder(cfg).WithConfigID(ConfigID).Build();

        var response = await clientMultiConfig.RedactText(new RedactTextRequest("Jenny Jenny... 415-867-5309") { ReturnResult = true });

        Assert.True(response.IsOK);
        Assert.Equal("<PERSON>... <PHONE_NUMBER>", response.Result.RedactedText);
        Assert.Equal(2, response.Result.Count);
        Assert.Null(response.Result.Report);
    }

    [Fact]
    public async Task TestLogMultiConfig_2()
    {
        var cfg = new Config(Config.GetMultiConfigTestToken(environment)) { Domain = Config.GetTestDomain(environment) };
        var ConfigID = Config.GetConfigID(environment, RedactClient.ServiceName, 2);
        var clientMultiConfig = new RedactClient.Builder(cfg).WithConfigID(ConfigID).Build();

        var response = await clientMultiConfig.RedactText(new RedactTextRequest("Jenny Jenny... 415-867-5309") { ReturnResult = true });

        Assert.True(response.IsOK);
        Assert.Equal("<PERSON>... <PHONE_NUMBER>", response.Result.RedactedText);
        Assert.Equal(2, response.Result.Count);
        Assert.Null(response.Result.Report);
    }

    [Fact]
    public async Task TestMultiConfigWithoutConfigID()
    {
        var cfg = new Config(Config.GetMultiConfigTestToken(environment)) { Domain = Config.GetTestDomain(environment) };
        var clientMultiConfig = new RedactClient.Builder(cfg).Build();

        await Assert.ThrowsAsync<PangeaAPIException>(async () => await clientMultiConfig.RedactText(new RedactTextRequest("Jenny Jenny... 415-867-5309") { ReturnResult = true }));
    }
}
