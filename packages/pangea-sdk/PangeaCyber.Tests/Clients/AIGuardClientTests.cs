using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using PangeaCyber.Net;
using PangeaCyber.Net.AIGuard;
using PangeaCyber.Net.AIGuard.Requests;
using PangeaCyber.Net.AIGuard.Models;
using Xunit;

namespace PangeaCyber.Tests.Clients;

public sealed class AIGuardClientTests
{
    private const string BASE_URL = "http://localhost:4010";

    private static async Task CheckTestServer(CancellationToken cancellationToken = default)
    {
        try
        {
            using var httpClient = new HttpClient();
            await httpClient.GetAsync(BASE_URL, cancellationToken: cancellationToken);
        }
        catch (Exception)
        {
            Skip.If(true, "Mock OpenAPI server is not running.");
        }
    }

    [SkippableFact]
    public async Task GuardText()
    {
        await CheckTestServer();

        var client = new AIGuardClient.Builder(new Config("token") { BaseUrlTemplate = "http://localhost:4010" }).Build();
        var response = await client.GuardText(new TextGuardRequest("hello world")
        {
            Recipe = "recipe",
            Debug = true
        });
        Assert.NotNull(response);
        Assert.True(response.IsOK);
        Assert.NotNull(response.Result);
    }

    [SkippableFact]
    public async Task Guard()
    {
        await CheckTestServer();

        var client = new AIGuardClient.Builder(new Config("token") { BaseUrlTemplate = "http://localhost:4010" }).Build();
        var response = await client.Guard(new GuardRequest()
        {
            Input = new Dictionary<string, object> {
                { "messages", new List<IDictionary<string, string>> {
                    new Dictionary<string, string> {
                        { "role", "user" },
                        { "content", "hello world" }
                    }
                } }
            },
            Recipe = "recipe",
            Debug = true,
            Overrides = new Overrides()
            {
                Image = new ImageOverride()
                {
                    Disabled = false,
                    Action = ImageAction.Report,
                    Topics = ["test"],
                    Threshold = 0.5
                }
            }
        });
        Assert.NotNull(response);
        Assert.True(response.IsOK);
        Assert.True(response.HttpResponse.IsSuccessStatusCode);
        Assert.NotNull(response.Result);
    }
}
