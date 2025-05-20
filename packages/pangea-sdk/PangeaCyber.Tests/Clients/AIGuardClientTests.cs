using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using PangeaCyber.Net;
using PangeaCyber.Net.AIGuard;
using PangeaCyber.Net.AIGuard.Models;
using PangeaCyber.Net.AIGuard.Requests;
using Xunit;
using CreateServiceConfigRequest = PangeaCyber.Net.AIGuard.Requests.CreateServiceConfigRequest;
using GetServiceConfigRequest = PangeaCyber.Net.AIGuard.Requests.GetServiceConfigRequest;
using ListServiceConfigsRequest = PangeaCyber.Net.AIGuard.Requests.ListServiceConfigsRequest;

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
    public async Task GetServiceConfig()
    {
        await CheckTestServer();

        var client = new AIGuardClient.Builder(new Config("token") { BaseUrlTemplate = "http://localhost:4010" }).Build();
        var response = await client.GetServiceConfig(new GetServiceConfigRequest("123"));
        Assert.NotNull(response);
        Assert.True(response.IsOK);
        Assert.NotNull(response.Result);
    }

    [SkippableFact]
    public async Task CreateServiceConfig()
    {
        await CheckTestServer();

        var client = new AIGuardClient.Builder(new Config("token") { BaseUrlTemplate = "http://localhost:4010" }).Build();
        var response = await client.CreateServiceConfig(new CreateServiceConfigRequest("123"));
        Assert.NotNull(response);
        Assert.True(response.IsOK);
        Assert.NotNull(response.Result);
    }

    [SkippableFact]
    public async Task UpdateServiceConfig()
    {
        await CheckTestServer();

        var client = new AIGuardClient.Builder(new Config("token") { BaseUrlTemplate = "http://localhost:4010" }).Build();
        var response = await client.UpdateServiceConfig(new UpdateServiceConfigRequest("id", "name"));
        Assert.NotNull(response);
        Assert.True(response.IsOK);
        Assert.NotNull(response.Result);
    }

    [SkippableFact]
    public async Task DeleteServiceConfig()
    {
        await CheckTestServer();

        var client = new AIGuardClient.Builder(new Config("token") { BaseUrlTemplate = "http://localhost:4010" }).Build();
        var response = await client.DeleteServiceConfig(new DeleteServiceConfigRequest("123"));
        Assert.NotNull(response);
        Assert.True(response.IsOK);
        Assert.NotNull(response.Result);
    }

    [SkippableFact]
    public async Task ListServiceConfigs()
    {
        await CheckTestServer();

        var client = new AIGuardClient.Builder(new Config("token") { BaseUrlTemplate = "http://localhost:4010" }).Build();
        var response = await client.ListServiceConfigs(new ListServiceConfigsRequest
        {
            Filter = new ServiceConfigListFilter
            {
                Id = "id",
                IdContains = ["id1", "id2"],
                CreatedAt = DateTimeOffset.UtcNow,
            },
        });
        Assert.NotNull(response);
        Assert.True(response.IsOK);
        Assert.NotNull(response.Result);
        Assert.NotNull(response.Result.Items);
    }
}
