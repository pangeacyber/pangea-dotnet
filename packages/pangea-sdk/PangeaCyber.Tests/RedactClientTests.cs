using Newtonsoft.Json;
using PangeaCyber.Net;
using PangeaCyber.Net.Redact;
using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Tests;

///
public class RedactClientTests
{
    private RedactClient client;
    TestEnvironment environment = TestEnvironment.LVE;

    ///
    public RedactClientTests()
    {
        var config = Config.FromIntegrationEnvironment(TestEnvironment.LVE);
        this.client = new RedactClient.Builder(config).Build();
    }

    [Fact]
    public async Task TestRedactText()
    {
        var response = await client.RedactText(new RedactTextRequest.Builder("Jenny Jenny... 415-867-5309").WithReturnResult(true).Build());

        Assert.True(response.IsOK);
        Assert.Equal("<PERSON>... <PHONE_NUMBER>", response.Result.RedactedText);
        Assert.Equal(2, response.Result.Count);
        Assert.Null(response.Result.Report);
    }

    [Fact]
    public async Task TestRedactText_2()
    {
        var response = await client.RedactText(new RedactTextRequest.Builder("Jenny Jenny... 415-867-5309").WithReturnResult(true).WithDebug(true).Build());

        Assert.True(response.IsOK);
        Assert.Equal("<PERSON>... <PHONE_NUMBER>", response.Result.RedactedText);
        Assert.Equal(2, response.Result.Count);
        Assert.NotNull(response.Result.Report);
    }

    [Fact]
    public async Task TestRedactText_3()
    {
        var response = await client.RedactText(new RedactTextRequest.Builder("Jenny Jenny... 415-867-5309").WithReturnResult(false).WithDebug(true).Build());

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
            { "Phone", "This is its number: 415-867-5309" }
        };

        var response = await client.RedactStructured(new RedactStructuredRequest.Builder(data).WithReturnResult(true).Build());
        var converted = ((Newtonsoft.Json.Linq.JObject)response.Result.RedactedData).ToObject<Dictionary<string, object>>();

        var expected = new Dictionary<string, object>
        {
            { "Name", "<PERSON>" },
            { "Phone", "This is its number: <PHONE_NUMBER>" }
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
            { "Phone", "This is its number: 415-867-5309" }
        };

        var response = await client.RedactStructured(new RedactStructuredRequest.Builder(data).WithFormat("json").WithReturnResult(true).Build());
        var converted = ((Newtonsoft.Json.Linq.JObject)response.Result.RedactedData).ToObject<Dictionary<string, object>>();

        var expected = new Dictionary<string, object>
        {
            { "Name", "<PERSON>" },
            { "Phone", "This is its number: <PHONE_NUMBER>" }
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
            { "Phone", "This is its number: 415-867-5309" }
        };

        var response = await client.RedactStructured(new RedactStructuredRequest.Builder(data).WithFormat("json").WithDebug(true).WithReturnResult(true).Build());
        var converted = ((Newtonsoft.Json.Linq.JObject)response.Result.RedactedData).ToObject<Dictionary<string, object>>();

        var expected = new Dictionary<string, object>
        {
            { "Name", "<PERSON>" },
            { "Phone", "This is its number: <PHONE_NUMBER>" }
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
            { "Phone", "This is its number: 415-867-5309" }
        };

        var response = await client.RedactStructured(new RedactStructuredRequest.Builder(data).WithFormat("json").WithJsonp(new String[] { "Phone" }).WithReturnResult(true).Build());
        var converted = ((Newtonsoft.Json.Linq.JObject)response.Result.RedactedData).ToObject<Dictionary<string, object>>();

        var expected = new Dictionary<string, object>
        {
            { "Name", "Jenny Jenny" },
            { "Phone", "This is its number: <PHONE_NUMBER>" }
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
            { "Phone", "This is its number: 415-867-5309" }
        };


        var response = await client.RedactStructured(new RedactStructuredRequest.Builder(data).WithFormat("json").WithJsonp(new String[] { "Name", "Phone" }).WithRules(new String[] { "PHONE_NUMBER" }).WithReturnResult(true).Build());
        var converted = ((Newtonsoft.Json.Linq.JObject)response.Result.RedactedData).ToObject<Dictionary<string, object>>();

        var expected = new Dictionary<string, object>
        {
            { "Name", "Jenny Jenny" },
            { "Phone", "This is its number: <PHONE_NUMBER>" }
        };

        Assert.True(response.IsOK);
        Assert.Equal(converted, expected);
        Assert.Equal(1, response.Result.Count);
        Assert.Null(response.Result.Report);
    }

     [Fact]
    public async Task testRedactTextUnauthorized()
    {
        Config cfg = Config.FromIntegrationEnvironment(environment);
		cfg.Token = "notarealtoken";
        var fakeClient = new RedactClient.Builder(cfg).Build();
        await Assert.ThrowsAsync<UnauthorizedException>(async () => await fakeClient.RedactText(new RedactTextRequest.Builder("Jenny Jenny... 415-867-5309").WithReturnResult(true).Build()));
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
        await Assert.ThrowsAsync<UnauthorizedException>(async () => await fakeClient.RedactStructured(new RedactStructuredRequest.Builder(data).WithReturnResult(true).Build()));
    }
}